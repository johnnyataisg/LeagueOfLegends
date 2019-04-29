$(document).ready(function () {
    console.log("jQuery is running as expected");

    $(".modal-trigger").click(function () {
        var passInValue = $(this).attr("value");
        var summonerName = $(this).attr("target");
        var target = $("#playerStatsModal");

        if (target.css("display") == "none") {
            target.find("p").first().text(passInValue);
            target.find("h4").first().text(summonerName);
            target.css("display", "inherit");
        }
    });

    $("#closeModalBtn").click(function () {
        $("#playerStatsModal").find("h4").first().text("");
        $("#playerStatsModal").find("p").first().text("");
        $("#playerStatsModal").css("display", "none");
    });
});