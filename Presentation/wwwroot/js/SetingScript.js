
function listar_Grados() {
    $("#loader").show();
    $.ajax({
        "url": "../Degrees/GetDegree",
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
                         <td>${valor.levels.levelname}</td>
                         <td>
                         <button class='btn' onclick = 'AddCourse(this)' style=' font-size:13px;Background:#424242'><i class='fa fa-plus-circle' style='color:White '></button></i>&nbsp;
                         <button class='btn ' onclick = 'ShowCourse(this)' style=' font-size:13px;Background:#FA5882'><i class='fa fa-eye' style='color:White '></button></i>
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

function CloseDivAddCurso() {
    $("#DivAgregarCurso").hide();
    $("#DivShowCurso").hide();
    $("#tbody_tabla_detall").html("");
    num = 1;
}

/* function AddCourse(t) {
     var td = t.parentNode;
     var tr = td.parentNode;
     var IdDegree = $(tr).attr('guardarId');

     $("#modad_pagos").modal({
         backdrop: 'static',
         keyboard: false
     })
     Listar_Combo_Cursos();
     $(".modal-header").css("background-color", "#ea899a");
     $(".modal-header").css("color", "white");
     $("#modad_pagos").modal('show');
     $("#IdDegree").val(IdDegree);
 }
 */

function AddCourse(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var IdDegree = $(tr).attr('guardarId');
    $("#IdDegree").val(IdDegree);
    Listar_Combo_Cursos();
    $("#DivShowCurso").hide();
    $("#DivAgregarCurso").show();

}

function Listar_Combo_Cursos() {
    $.ajax({
        "url": "../Courses/SelectCuersos",
        type: 'POST',
    }).done(function (resp) {
        var cadena = "";
        if (resp.length > 0) {
            for (var i = 0; i < resp.length; i++) {
                cadena += '<option value="' + resp[i].idCourse + '">' + resp[i].courseName + '</option>';
            }
            $("#IdCourse").html(cadena);
        } else {
            cadena += '<option value="' + '">' + 'NO SE ENCONTRARON REGISTROS' + '</option>';
            $("#IdCourse").html(cadena);
        }
    })

}


var num = 1;
function Agregar_detall() {
    var select = document.getElementById("IdCourse");
    var nombreCurso = $('#IdCourse option:selected').text();
    var IdCourse = select.value;
    if (verificaridCurso(IdCourse)) {
        return Swal.fire("Mensaje de Advertencia", "Curso ya esta seleccionado!", "warning");
    }
    var datos_add = "<tr>";
    datos_add += "<td >" + num + "</td>";
    datos_add += "<td for='id' hidden>" + IdCourse + "</td>";
    datos_add += "<td >" + nombreCurso + "</td>";
    datos_add += "<td><button class='btn' onclick = 'remove(this)' style='Background:#ee707d'> <i class='fa fa-close' style='color:#FBF8EF'></button></i></td>";
    datos_add += "<tr>";
    num++;
    $("#tbody_tabla_detall").append(datos_add);
}

function verificaridCurso(IdCourse) {
    let ident = document.querySelectorAll('#tbody_tabla_detall td[for="id"]');
    return [].filter.call(ident, td => td.textContent == IdCourse).length == 1;
}

function remove(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var table = tr.parentNode;
    table.removeChild(tr);
    num--;
}

function VaciarTable() {

    $("#tbody_tabla_detall").html("");
    num = 1;
}

function RegistrarCursoGrado() {
    var Gradoid = $('#IdDegree').val();
    var cont = 0;
    var ArrarCursos = new Array();
    $('#tbody_tabla_detall#tbody_tabla_detall tr').each(function () {
        ArrarCursos.push($(this).find('td').eq(1).text());
        cont++;
    })
    var Cursos = ArrarCursos.toString();
    if (cont == 0) {
        return;
    }
    $.ajax({
        "url": "../GradosCurso/Post",
        type: 'POST',
        data: {
            Gradoid: Gradoid,
            Cursos: Cursos
        }
    }).done(function (result) {
        Mensajeria(result)
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });

}

function ShowCourse(t) {
    $("#DivAgregarCurso").hide();
    var td = t.parentNode;
    var tr = td.parentNode;
    var idDegree = $(tr).attr('guardarId');
    $("#ShowIdGrado").val(idDegree);
    $("#DivShowCurso").show();
    $.ajax({
        "url": "../GradosCurso/GetGradoCursosLista",
        type: 'POST',
        data: {
            idDegree: idDegree
        }
    }).done(function (result) {
      MostarCursosdelGraoSeleccionado(result);
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });  
}

function MostarCursosdelGraoSeleccionado(result) {
    if (result.length != 0) {
       
        console.log(result);
        var cont = 1;
        var template = '';
        result.forEach(valor => {
            template += `
                        <tr guardarId="${valor.courses.idCourse}" >
                         <td> ${cont}</td>
                         <td>${valor.courses.courseName}</td>
                         <td>
                         <button id='ButtQuit' class='btn' onclick = 'QuitarCursos(this)' style=' font-size:13px; Background:#e4007c'> <i class='fa fa-trash' style='font-size:13px;color:#FBF8EF'></button></i>
                         </td>
                         </tr>  `
            cont++;
        });
        $('#ShowCourses').html(template);
       
    } else {
        $('#ShowCourses').html('<b>NO HAY NINGUN CURSO REGISTRADO !!</b>');
    }

}

function QuitarCursos(t) {
   var td = t.parentNode;
    var tr = td.parentNode;
    var idCouse = $(tr).attr('guardarId');

    $("#loaderQuit").show();
    $.ajax({
        url: "../GradosCurso/QuitarCursoGrado",
        type: 'POST',
        data: {
            idCouse: idCouse
        }
    }).done(function (result) {
        if (result != 0) {
            $("#loaderQuit").hide();
            Actualizartable();
        } else {}
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}
// // Listgradocurso = context.GradosCurso.Where(u => u.CoursesIdCourse == idCouse).Select(x => x).ToList();
function Actualizartable() {
    var idDegree= $("#ShowIdGrado").val();
    $.ajax({
        "url": "../GradosCurso/GetGradoCursosLista",
        type: 'POST',
        data: {
            idDegree: idDegree
        }
    }).done(function (result) {
        MostarCursosdelGraoSeleccionado(result);
    }).fail(function (XMLHttpRequest, status, error) {
        SaveExcepciones(XMLHttpRequest, status, error);
    });
}

function Mensajeria(result) {
    if (result == null) {
        $("#NoAction").show("slow").delay(2000).hide("slow");
        return;
    }

    if (result > 0) {
        VaciarTable();
        $("#DivAgregarCurso").hide();
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
        console.log(XMLHttpRequest);
        return;
    }
    Swal.fire(
        '' + XMLHttpRequest.statusText + '',
        'That thing is ' + XMLHttpRequest.responseText + ' still around?',
        'error'
    )
    $("#loaderQuit").hide();
}
