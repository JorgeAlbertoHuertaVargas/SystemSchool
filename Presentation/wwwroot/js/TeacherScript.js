
function valideKey() {
    let imputCod = document.getElementById('inputCode')
    let ImputPhon = document.getElementById('inputPhone')

    imputCod.addEventListener('keypress', (event) => {
        event.preventDefault()
        // console.log(event.keyCode)
        let valorTecla = String.fromCharCode(event.keyCode)
        let valorParsed = parseInt(valorTecla)
        if (valorParsed || valorParsed == 0) {
            imputCod.value = imputCod.value + valorParsed
        }
    })

    ImputPhon.addEventListener('keypress', (event) => {
        event.preventDefault()
        // console.log(event.keyCode)
        let valorTecla = String.fromCharCode(event.keyCode)
        let valorParsed = parseInt(valorTecla)
        if (valorParsed || valorParsed == 0) {
            if (ImputPhon.length!=9) {
                ImputPhon.value = ImputPhon.value + valorParsed
            }
            
        }
    })
}


function GetAllTeacher() {
    $.ajax({
        url: "Teacher/GetAllTeacher",
        type: 'GET'
    }).done(function (resp) {
        var cont = 1;
        if (resp.length != 0) {
            var cont = 1;
            var template = '';
            for (var i = 0; i < resp.length; i++) {


                template += `
                             
                             <tr guardarId="${resp[i].idTeacher}">
                             <td>
                              <button  class="btn btn-info" onclick ='ShowAssign(this)'><i class="fas fa-plus"></i></button>
                              <button  class="btn btn-info" onclick ='ShowTeacher(this)' data-toggle="modal" data-target="#EditTeacher"><i class="fas fa-pencil-alt"></i></button>
                              <button type="reset" class="btn btn-danger"  onclick='DeleteTeacher(this)'><i class="fas fa-times"></i></button>
                             </td>
                             <td><a>${resp[i].firstName}</a></td>
                             <td><a>${resp[i].lastName}</a></td>
                             <td><a>${resp[i].phone}</a></td>
                             <td><a>${resp[i].user.userName}</a></td>
                                
                             `
                cont++;
            }
            $('#Table_Teacher').html(template);

        }

    })

}

function ShowAssign(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var id = $(tr).attr('guardarId');
    window.location = "Teacher/Assign?idTeacher="+id;
}

function ShowTeacher(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var id = $(tr).attr('guardarId');
    $.ajax({
        url: "Teacher/GetTeacher",
        type: 'POST',
        data: {
            idtea: id
        },
    }).done(function (resp) {
        $("#IdTeacher").val(resp.idTeacher);
        $("#IdUserr").val(resp.userIdUser);
        $("#EditName").val(resp.firstName);
        $("#EditLastName").val(resp.lastName);
        $("#EditPhone").val(resp.phone);

    })
}

function Update_Teacher() {
    $.ajax({
        url: "Teacher/Edit",
        type: "POST",
        data: {
            idTeacher: $("#IdTeacher").val(),
            userIdUser: $("#IdUserr").val(),
            firstName: $("#EditName").val(),
            lastName: $("#EditLastName").val(),
            phone: $("#EditPhone").val()
        },

    }).done(function (resp) {
        if (resp) {
            swal({
                type: "success",
                title: "Los datos se registrarón correctamente",
                showConfirmButton: true,
                confirmButtonText: "Cerrar",
                closeOnConfirm: false
            }).then(function (result) {
                    if (result.value) {
                        window.location = "Teacher";
                    }
                })
        }
    })
}

function DeleteTeacher(t) {
    swal({
        title: '¿Está seguro de eliminar al docente?',
        text: "¡Si no lo está puede cancelar la acción!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Si!'
    }).then(function (result) {
        if (result.value) {
            var td = t.parentNode;
            var tr = td.parentNode;
            var IdTeacher = $(tr).attr('guardarId');
            console.log(IdTeacher);
            $.ajax({
                url: "Teacher/Delete",
                type: 'POST',
                data: {
                    id: IdTeacher
                },
            }).done(function (resp) {
                window.location = "Teacher";
            })
        }
    })
}

$(".btn-regresar").click(function () {
    window.location = "../Teacher"
})

$(".btn-register").click(function () {
    var codigo = document.getElementById('inputCode').value;
    var nombre = document.getElementById('inputName').value;
    var apellido = document.getElementById('inputLastName').value;
    var telefono = document.getElementById('inputPhone').value;
    var usuario = document.getElementById('inputUser').value;
    var contraseña = document.getElementById('inputPass').value;

    if (codigo.length != 0 && nombre.length != 0 && apellido.length != 0 && telefono.length != 0 && usuario.length != 0 && contraseña.length != 0) {
        //prueba = $("#inputCode").val();
        //alert(prueba)
        $.ajax({
            url: "ValidationUser",
            data: {
                code: $("#inputCode").val(),
                user: $("#inputUser").val()
            },
            type: 'POST'
        }).done(function (Resp) {
            if (Resp != true) {
                $.ajax({
                    url: "AddUser",
                    data: {
                        userName: $("#inputUser").val(),
                        pass: $("#inputPass").val(),
                        roleIdRole: $("#idRol").val(),
                        codigo: $("#inputCode").val()
                    },
                    type: 'POST'
                }).done(function (Resp) {
                    $.ajax({
                        url: "GetUser",
                        type: 'GET'
                    }).done(function (Resp) {
                        for (var i = 0; i < Resp.length; i++) {
                            var idUserr = Resp[i].idUser;
                        }
                        var id = idUserr;
                        $("#idUsers").val(id);
                        $.ajax({
                            url: "Create",
                            data: {
                                userIdUser: $("#idUsers").val(),
                                firstName: $("#inputName").val(),
                                lastName: $("#inputLastName").val(),
                                phone: $("#inputPhone").val()
                            },
                            type: 'POST'
                        }).done(function (resp) {
                            $.ajax({
                                url: "GetAllTeacher",
                                type: 'GET'
                            }).done(function (Resp) {
                                for (var i = 0; i < Resp.length; i++) {
                                    var idTeacherr = Resp[i].idTeacher;
                                }
                                var id = idTeacherr;
                                swal({
                                    type: "success",
                                    title: "El docente se registro correctamente",
                                    showConfirmButton: true,
                                    confirmButtonText: "Cerrar",
                                    closeOnConfirm: false
                                }).then(function (result) {
                                    if (result.value) {
                                        window.location = "Assign?idTeacher=" + id;
                                    }
                                })
                            })
                        })
                    })
               })
            }else {
                $("#Chekname").show("slow").delay(2000).hide("slow");
                return;
            }
        })
    } else {
        $("#validationform").show("slow").delay(2000).hide("slow");
        return;
    }
})

