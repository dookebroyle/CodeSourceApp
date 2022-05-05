var URL = "";
var ID = "";
function AskQuestion(url, id) {
    console.log(id);
    $("#modalmessage").modal();
    URL = url;
    ID = id;
}
function Delete() {
    console.log(ID);
    $.ajax(
        {
            url: URL + ID,
            type: "POST",
            success: function (result) {
                $("#a_" + ID).fadeOut();
                $("#modalmessage").modal('hide');
                console.log('Success: '+ result);
            },
            error: function (req, err) { console.log('Error: ' + err);}
        }
    )
}