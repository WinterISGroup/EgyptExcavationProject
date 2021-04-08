// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ViewRecord(url) {
    location.href = url;
}

function ExpandFilter() {
    if ($("#filter-main").hasClass("filter-main-expanded")) {
        $("#filter-main").removeClass("filter-main-expanded");
    }
    else {
        $("#filter-main").addClass("filter-main-expanded");
    }
}