<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/CodeRank.Master" Inherits="System.Web.Mvc.ViewPage<CodeRank.Shared.Data.Question>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    QuestionPaper
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/ProjectScript/CodeRankJavaScript.js"></script>
    <div id="divQuestionSet" class="mainContent">
        <div class="questionSet">
        <div id="divQuestion" >

            <b>QUESTION</b><br/>
            <span id="Question" QID=""></span>
                </div>
      </div>
              <div style="height: auto; min-width: 800px;">
            <div style="width: 100%; height: 30px;margin-top:4%;">
                <label style="float: left"><b>Current Buffer</b></label>
                <select style="float: right">
                    <option value="c#">C#</option>
                    <option value="java">Java</option>
                    <option value="Javascript">Javascript</option>
                    <option value="PHP">PHP</option>
                </select>
            </div>
            <textarea style="height: 100px; width: 100%;" id="answer">

            </textarea>
        </div>
        <div style="float:right">
            <input type="button" value="Run Code" style="margin-right:10px;" />
            <input type="button" value="Submit Code" id="Submit"/>
        </div>

    </div>


</asp:Content>
