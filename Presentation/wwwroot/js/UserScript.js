$(".btn-create").click(function () {
    $.ajax({
        url: "Create",
        data: {
            userName: $("#name").val(),
            pass: $("#pass").val(),
            idRolee: $("#comboRole").val(),
            dateCreated: $("#date").val()
        },
        type: 'POST'
    })
    })




