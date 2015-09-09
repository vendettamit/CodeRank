var HomeHelper = function(){

}


HomeHelper.prototype.BindEvents = function () {
    home.GetQuestions();
    $("#Submit").click(function () {
        home.SubmitAnswer();
    });
}

HomeHelper.prototype.GetQuestions = function () {
    $.post("CodeRank/GetQuestion", function (result) {
        $("#Question").html(result.Description);
        $("#Question").attr("QID",result.QuestionId)
    });
}

HomeHelper.prototype.SubmitAnswer = function () {
    var solution = {
        SolutionDescription: $("#answer").text(),
        QuestionId: $("#Question").attr("QID")
    };
    $.post("CodeRank/SubmitAnswer",solution, function (result) {
        $("#Question").html(result.Description);
    });
}

var home = '';
$(document).ready(function () {
    home = new HomeHelper();
    home.BindEvents();
});