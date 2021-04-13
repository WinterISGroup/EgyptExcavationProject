// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ViewRecord(url) {
    location.href = url;
}

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

function HideFilter() {
    $("#filter-main").hide();
}

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

//function RequiredLocationInput() {
//    alert("ALTERTEDSKFSDJKFsjdhg");
//    $("#square").filter(":input").prop('required', true);
//    $("#subplot").filter(":input").prop('required', true);
//}

function ShowPhotoUpload() {
    $("#add-photo-btn").hide();
    $("#photo-upload").show();
}

function getFileName(obj) {
    var file = obj.value;
    var fileName = file.split("\\");
    document.getElementById("fileName").innerHTML = "<b>Uploaded Image: </b> " + fileName[fileName.length - 1];
    $("#upload-btn").show();
    $("#photo-btn").hide();
}