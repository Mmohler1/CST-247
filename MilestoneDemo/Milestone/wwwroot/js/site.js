$(function () {

    $(document).ready(function () {

        $(document).on("mousedown", ".game-button", function (e) {

            if (e.button == 2) {
                event.preventDefault();

                var squareNumber = $(this).val();
                console.log("Square Number " + squareNumber + " was Right clicked");
                doFlag(squareNumber);

            }
        });
    });


    //This works with for any game button elements
    $(document).on("click", ".game-button", function (event) {
        event.preventDefault();

        var squareNumber = $(this).val();
        console.log("Square Number " + squareNumber + " was clicked");
        doPageUpdate(squareNumber);
        //doCheckWin();

    });


});

//Updates the partial page, which includes the entire field and viewbags
function doPageUpdate(squareNumber) {
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: '/Minesweeper/_ViewMinesweeperPartial', //which method in controller
        data: {
            "squareNumber": squareNumber    //what is the paramter equal to. 
        },
        success: function (data) {
            console.log(data);
            $("#gameZone").html(data); //html data is reloading the entire page.
        }


    });

};

//Updates the partial page, which includes the entire field and viewbags
function doFlag(squareNumber) {
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: '/Minesweeper/RightClickFlag',
        data: {
            "squareNumber": squareNumber    //what is the paramter equal to. 
        },
        success: function (data) {
            console.log(data);
            $("#gameZone").html(data); //html data is reloading the entire page.
        },
        error: function (jqXHR, textStatus) {
            alert("Failed");
        }

    });

};



