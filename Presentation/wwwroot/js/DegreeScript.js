
function listar_Grados() {
    $("#loader").show();
    $.ajax({
        "url": "Degrees/GetDegree",
        type: 'GET'
    }).done(function (resp) {
        $("#loader").hide();
        if (resp.length != 0) {
            var cont = 1;
            var template = '';
            resp.forEach(valor => {
                template += `
                         <tr guardarId="${valor.idDegree}" >
                         <td> ${cont}</td>
                         <td>${valor.degreeName}</td>
                         <td>${fecha(valor.degreeDateCreated)}</td>
                         <td>${valor.numStudent}</td>
                         <td>${valor.levels.levelname}</td>
                         <td>
                          <button class='btn btn-info' onclick = 'ShowDegre(this)' style=' font-size:13px;'> <i class='fa fa-edit' style=' font-size:13px;'></button></i>&nbsp;
                         <button class='btn ' onclick = 'QuitarDegre(this)' style=' font-size:13px;Background:#e4007c'> <i class='fa fa-trash'style=' font-size:13px;color:#FBF8EF'></button></i>
                         </td>
                         </tr>`
                cont++;
            })
            $('#contenido').html(template);
        } else {
            $('#contenido').html('NO HAY REGISTRO');
        }
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}

var editar = false;
function RegisterGrados() {
    var estunum = $("#NumStudent").val();
    if (estunum.length == 3) { return; }
    $.ajax({
        url: editar === false ? "Degrees/RegistrarGrados" : "Degrees/UpdateDegree",
        data: {
            IdDegree: $("#IdDegree").val(),
            DegreeName: $("#DegreeName").val(),
            DegreeDateCreated: $("#DegreeDateCreated").val(),
            NumStudent: $("#NumStudent").val(),
            LevellId: $("#LevellId").val()
        },
        type: "post"
    }).done(function (result) {
        console.log(result);
        Mensajeria(result);
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error)
    });
}

function QuitarDegre(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var IdDegree = $(tr).attr('guardarId');
    console.log(IdDegree);
    $.ajax({
        url: "Degrees/DeleteDegree",
        type: 'POST',
        data: {
            IdDegree: IdDegree
        },
    }).done(function (result) {
        Mensajeria(result);
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error)
    });
}

function ShowDegre(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var IdDegree = $(tr).attr('guardarId');
    $.ajax({
        url: "Degrees/ShowDegree",
        type: 'POST',
        data: {
            IdDegree: IdDegree
        },
    }).done(function (result) {
        if (result.length != 0) {
            editar = true;
            Listar_Combo_Level();
            HidenShowButtonTitle();
            $('#IdDegree').val(result["idDegree"]);
            $('#DegreeName').val(result["degreeName"]);
            $('#DegreeDateCreated').val(result["degreeDateCreated"]);
            $('#NumStudent').val(result["numStudent"]);

        } else {
            Mensajeria(result);
        }
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });

}

//FUNCIONES ADICIONALES
function Listar_Combo_Level() {
    $.ajax({
        "url": "Degrees/GetLevel",
        type: 'GET'
    }).done(function (resp) {
        var cadena = "";
        fechaCreate();
        if (resp.length > 0) {
            for (var i = 0; i < resp.length; i++) {
                cadena += '<option value="' + resp[i].id + '">' + resp[i].levelname + '</option>';
            }
            $("#LevellId").html(cadena);
        } else {
            cadena += '<option value="' + '">' + 'NO SE ENCONTRARON REGISTROS' + '</option>';
            $("#LevellId").html(cadena);
        }
    }).fail(function (XMLHttpRequest, status, error) {

    });
}

function Buscar() {
    var tabla = document.getElementById('htmlTable');
    var busqueda = document.getElementById('BuscadorFilter').value.toLowerCase();
    var cellsOfRow = "";
    var found = false;
    var compareWith = "";
    for (var i = 1; i < tabla.rows.length; i++) {
        cellsOfRow = tabla.rows[i].getElementsByTagName('td');
        found = false;
        for (var j = 0; j < cellsOfRow.length && !found; j++) {
            compareWith = cellsOfRow[j].innerHTML.toLowerCase(); if (busqueda.length == 0 || (compareWith.indexOf(busqueda) > -1)) {
                found = true;
            }
        }
        if (found) {
            tabla.rows[i].style.display = '';
        } else {
            tabla.rows[i].style.display = 'none';
        }
    }
}

function fechaCreate() {
    var f = new Date();
    DegreeDateCreated.value = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate();
}

function HidenShowButtonTitle() {
    $("#ButtCreat").hide();
    $("#ButtUpdate").show();
    $("#titlenew").hide();
    $("#titleEdit").show();
    $("#ButtLipiar").show();
}

function fecha(fechaSelec) {
    var f = new Date(fechaSelec);
    var options = { year: 'numeric', month: 'long', day: 'numeric' };
    var selectFecha = (f.toLocaleDateString("es-ES", options));
    return selectFecha;
}

function LimpiarInput() {
    $("#IdDegree").val('');
    $("#DegreeName").val('');
    $("#DegreeDateCreated").val('');
    $("#NumStudent").val('');
    fechaCreate();

}




$("#DegreeName").blur(function () {
    if ($("#DegreeName").val() != '') {
        $.ajax({
            url: "Degrees/CheckNameDegre",
            type: 'Post',
            data: { DegreeName: $("#DegreeName").val() }
        }).done(function (result) {
            if (result == true) { $("#NombreExiste").show(); } else {
                $("#NombreExiste").hide();
            }
        })
    }
});





function ButtCancelar() {
    LimpiarInput();
    $("#titlenew").show();
    $("#titleEdit").hide();
    $("#ButtCreat").show();
    $("#ButtUpdate").hide();
    $("#ButtLipiar").hide();
    editar = false;
}






var con = 0;
function Actibarbuscador() {
    if (con == 0) {
        $("#BuscadorFilter").show();
        con++;
    } else {
        $("#BuscadorFilter").hide();
        con = 0;
    }
}

function Mensajeria(result) {

    if (result == true) {
        $("#Chekname").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result == false) {
        $("#NoAction").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result == null) {

        $("#LLeneCmpVacio").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result > 0) {
        $("#ButtCreat").show();
        $("#ButtUpdate").hide();
        $("#titlenew").show();
        $("#titleEdit").hide();
        $("#ButtLipiar").hide();
        LimpiarInput();
        editar = false;
        listar_Grados();
        $("#ExitoAlert").show("slow").delay(2000).hide("slow");
        return;

    }
}

function SaveExcepciones(XMLHttpRequest, status, error) {
    if (XMLHttpRequest.status == 401) {
        $("#ErrorAlert").show("slow").delay(2000).hide("slow");
        $('#Mensenger').html('petición HTTP Fallido:' + xhr.status + ' Not authorized');
        $("#loader").hide();
        return;
    }
    if (XMLHttpRequest.status == 404) {
        $("#ErrorAlert").show("slow").delay(2000).hide("slow");
        $('#Mensenger').html('Código de estado:' + XMLHttpRequest.status + '  the route does not exist!');
        $("#loader").hide();
        return;
    }

    if (XMLHttpRequest.status == 500) {
        $("#ErrorAlert").show("slow").delay(2000).hide("slow");
        $('#Mensenger').html('Código de estado:' + XMLHttpRequest.status + ' Error Interno del Servidor');
        $("#loader").hide();
        return;
    }
    Swal.fire(
        '' + XMLHttpRequest.statusText + '',
        'That thing is ' + XMLHttpRequest.responseText + ' still around?',
        'error'
    )
}




