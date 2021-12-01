 
    function listar_Levell() {
        $.ajax({
            "url": "ObtenerTodos",
            type: 'GET'
        }).done(function (resp) {
            var cont = 1;
            if (resp.length != 0) {
                var cont = 1;
                var template = '';
                for (var i = 0; i < resp.length; i++) {


                        template += `
                             <tr guardarId="${resp[i].id}">
                             <td>${i}</td>
                             <td><a>${resp[i].levelname}</a></td>
                             <td><a>${resp[i].turn}</a></td>
                             <td>
                              <button  class="btn btn-info" onclick = 'ShowLevell(this)'data-toggle="modal" data-target="#EditarLevel"><i class="fas fa-pencil-alt"></i></button>
                              <button type="reset" class="btn btn-danger"  onclick='QuitarLevel(this)'><i class="fas fa-trash-alt"></i></button>
                             </td>

                             `
                    cont++;
                }
                $('#Datos').html(template);

            }

        })

    }

    function ShowLevell(t) {

                var td = t.parentNode;
    var tr = td.parentNode;

    var id = $(tr).attr('guardarId');

    $.ajax({
        "url":"GetLevel",
    type: 'POST',
    data: {
        id: id
        },
     }).done(function (resp) {
    $("#idLevel").val(resp.id);
    $("#EditarName").val(resp.levelname);
    $("#EditarTurno").val(resp.turn);

       })
  }

    function Update_Level() {
        $.ajax({
            url: "EditLevel",
            type: "POST",
            data: {
                id: $("#idLevel").val(),
                levelname: $("#EditarName").val(),
                turn: $("#EditarTurno").val()
            },     

        }).done(function (resp) {
   
            toastr.success("Your request has been successfully added.", 'Success Alert', { timeout: 100 });
           
        })
    }



    function QuitarLevel(t) {
            var td = t.parentNode;
    var tr = td.parentNode;
    var IdLevel = $(tr).attr('guardarId');
    console.log(IdLevel);
    $.ajax({
        url: "DeletLevel",
    type: 'Post',
    data: {
        id: IdLevel
                },
            }).done(function (resp) {

            listar_Levell();
            toastr.success("Your request has been successfully added.", 'Success Alert', { timeout: 100 });
            })

        }

