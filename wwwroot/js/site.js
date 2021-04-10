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
    }
    else {
        $("#cluster_data").hide();
    }
}