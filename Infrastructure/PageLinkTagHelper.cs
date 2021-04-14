using EgyptExcavationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;
        public PaginationTagHelper(IUrlHelperFactory uhf) //Uses the IUrlHelperFactory whenever a new instance of the class is created
        {
            urlInfo = uhf;
        }

        //This stores the info the tag gets from the Index page
        public PageNumInfo pageInfo { get; set; }

        //Creating a new dictonary to hold the pages that will be made into the page number a tags
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext viewContext { get; set; }

        //Bootstrap
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Override the original Process tag helper function
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder finishedTag = new TagBuilder("div"); //build a div tag to hold the page numbers

            for (int i = 1; i <= pageInfo.NumPages; i++) //For loop to make a tag for each page
            {
                int pageNow = pageInfo.CurrentPage;
                int numsShown = 4;                      //How many page numbers to show in a section

                if (pageInfo.NumPages < 10)
                {
                    numsShown = 3;
                }


                IUrlHelper urlHelp = urlInfo.GetUrlHelper(viewContext);

                //An if statement to only make a certain portion of the overall pages number buttons, so that there aren't a
                //large number of page number buttons shown on the page.
                //Dynamically changes what numbers are shown based on what page number is selected and how many
                //total pages there are
                if ((i <= (pageNow + numsShown) && i >= pageNow) || (i < numsShown) || (i > (pageInfo.NumPages - (numsShown - 1))))
                {
                    TagBuilder individualTag = new TagBuilder("a"); //build an new a tag each time for each page number

                    //Create dictionaries to hold page numbers and if pagination info
                    KeyValuePairs["pageNum"] = i;
                    KeyValuePairs["isPagination"] = true;

                    //Set up info for each a tag
                    individualTag.Attributes["href"] = urlHelp.Action("BurialRecords", KeyValuePairs);

                    if (PageClassesEnabled)
                    {
                        individualTag.AddCssClass(PageClass);                                       //Highlighting the page numbers
                        individualTag.AddCssClass(i == pageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    individualTag.InnerHtml.Append(i.ToString());

                    //Put the finished individual a tag to the div
                    finishedTag.InnerHtml.AppendHtml(individualTag);

                    //Creates the "..." buffer unclickable elements to seperate between non sequential numbers in the pagination list
                    if ((i == numsShown - 1) || ((i == (pageNow + numsShown)) && (i != pageInfo.NumPages)))
                    {
                        //Only does this if the number of pages is 8 or less
                        if (pageInfo.NumPages <= 5)
                        {

                        }

                        else
                        {
                            TagBuilder spaceTag = new TagBuilder("span");

                            spaceTag.InnerHtml.Append("...");

                            spaceTag.AddCssClass(PageClass);
                            spaceTag.AddCssClass(PageClassNormal);

                            finishedTag.InnerHtml.AppendHtml(spaceTag);
                            i++;
                            i++;
                        }

                    }
                }

            }
            //Put the finished div tag of all the page buttons onto the page
            output.Content.AppendHtml(finishedTag.InnerHtml);
        }
    }
}