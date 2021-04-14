// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/**
 * ViewRecord function:
 * passes in a url as the parameter to allow you to click on a card to route to the home controller
 */
function ViewRecord(url) {
    location.href = url;
}

/**
 * ExpandFilter function:
 * when the more button is clicked, the div that contains the filter form expands so the user can fill out
 * the rest of the form
 * */
function ExpandFilter() {
    var filterBox = $("#filter-main");

    if (!filterBox.hasClass("filter-main-expanded")) {
        filterBox.addClass("filter-main-expanded");
        
        var lastRow = $("#lastrow");
        var middleRow = $("#middlerow");

        lastRow.toggle();
        middleRow.toggle();
    }
}

/**
 * ShrinkFilter function:
 * when the less button is clicked, the div that contains the filter form shrinks if the user doesn't
 * want to see part of the form
 * */
function ShrinkFilter() {
    var filterBox = $("#filter-main");

    if (filterBox.hasClass("filter-main-expanded")) {
        filterBox.removeClass("filter-main-expanded");

        var lastRow = $("#lastrow");
        var middleRow = $("#middlerow");

        lastRow.toggle();
        middleRow.toggle();
    }
}

/**
 * HideFilter function:
 * hides the filter form from the user
 * */
function HideFilter() {
    $("#filter-main").hide();
}

/**
 * ShowOrHideShafts function:
 * if user clicks yes on the shared shaft radio button, then other inputs are shown for the user to put in
 * if the user clicks no, then the inputs do not appear
 */
function ShowOrHideShafts(selected) {
    if (selected == "Y") {
        $("#shaft_nums").show();
    }
    else if (selected == "N") {
        $("#shaft_nums").hide();
    }
    else {
        $("#shaft_nums").hide();
    }
}

/**
 * ShowOrHideClusters function:
 * if user clicks yes on the cluster radio button, then other radio buttons appear and the user is required to input
 */
function ShowOrHideClusters(selected) {
    if (selected == "Y") {
        $("#cluster_data").show();
        document.getElementById("radio1").required = true;
        document.getElementById("radio2").required = true;
        document.getElementById("radio3").required = true;
        document.getElementById("radio4").required = true;
        document.getElementById("radio5").required = true;
    }
    else {
        $("#cluster_data").hide();
    }
}

/**
 * ShowPhotoUpload function:
 * this hides the add photo button and displays the photo upload
 * */
function ShowPhotoUpload() {
    $("#add-photo-btn").hide();
    $("#photo-upload").show();
}

/**
 * getFileName function:
 * inserts html into a b tag of the filename and then shows the upload button and hides the photo button
 */
function getFileName(obj) {
    var file = obj.value;
    var fileName = file.split("\\");
    document.getElementById("fileName").innerHTML = "<b>Uploaded Image: </b> " + fileName[fileName.length - 1];
    $("#upload-btn").show();
    $("#clear-photo").show();
    //$("#photo-btn").hide();
}
function clearPhoto() {
    document.getElementById("fileName").innerHTML = "Choose another file";
    document.getElementById("file-upload").value = "";

}
/**
 * the textbox auto resizes to the length of the text of the burial notes
 */
$(document).ready(function () {
    document.getElementById("burial-notes").style.height = 'auto';
    document.getElementById("burial-notes").style.height = document.getElementById("burial-notes").scrollHeight + 'px';
});

/**
 * puts an event listener so the user cannot click the filter button if a filter has not been selected
 */
var form = document.getElementById("filterForm");
if (form != null) {
    form.addEventListener("input", function () {
        document.getElementById("filterSubmitBtn").removeAttribute("disabled");
    });
}


