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

    $("#commitImport").click(function () {
        $(".screenLoader").toggle();
        console.log("Starting database import");
        $.ajax({
            url: "/Admin/CommitImport"
        }).done(function (content) {
            console.log(content);
            $(".screenLoader").toggle();
        });
    });

    $(".picture-tile").click(function () {
        $(".screenLoader").toggle();
        $.ajax({
            url: "/Home/ChampionData",
            data: { championKey : $(this).attr("value") }
        }).done(function (content) {
            $("#championDataContainer").html(content);
            $(".screenLoader").toggle();
        });
    });
});