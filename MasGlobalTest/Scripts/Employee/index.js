var table; // use a global for the submit and return data rendering in the examples
var page = 1;
var rows = 5;
var fconsult = false;
var tconsult = "";

$(document).ready(function () {
    console.log('Products Setting');
});

$('#btnSearch').click(function (e) {
    console.log('Search clicked');
    getEmployee();
});

function getEmployee() {
    console.log('data');
    var data = $('#employeeId').val();
    console.log(data);
    if (data == null || data == "") {
        tconsult = "all";
        getEmployees();

    }
    else {
        tconsult = "byId";
        getEmployeebyId(data);
        $('#employeeId').val("");
    }
}

function getEmployees() {
    console.log("Consult employees");
    openSpinner('spinnerTable');
    $.ajax({
        async: true,
        type: 'GET',
        url: '/api/Employees/GetAllEmployees',
        data: { page: page, rows: rows },
        dataType: 'json',
        success: function (data) {
            //alert("View Model Passed Successfully");
            console.log(data);
            var dataJson = JSON.parse(data);
            if (dataJson.IsValid) {
                setTableData(dataJson.ContentResult)
            }
            else {
                alert(dataJson.Error.ErrorMessage);
            }
            closeSpinner('spinnerTable');
        },
        error: function (er) {
            alert("Something was wrong");
            closeSpinner('spinnerTable');
            console.log(er);
        }
    });
}

function getEmployeebyId(data) {
    console.log("Consult employee");
    openSpinner('spinnerTable');
    var list = [];
    $.ajax({
        async: true,
        type: 'GET',
        url: '/api/Employees/GetEmployee',
        data: { idNumber: data},
        dataType: 'json',
        success: function (data) {
            //alert("View Model Passed Successfully");
            console.log(data);
            var dataJson = JSON.parse(data);
            if (dataJson.IsValid) {
                list.push(JSON.parse(dataJson.ContentResult));
                setTableData(JSON.stringify(list));
            }
            else {
                alert(dataJson.Error.ErrorMessage);
            }
            closeSpinner('spinnerTable');
        },
        error: function (er) {
            alert("Something was wrong");
            closeSpinner('spinnerTable');
            console.log(er);
        }
    });
}

function setTableData(contentResult) {
    console.log('Set data into the table');
    var data = JSON.parse(contentResult);
    if (fconsult) {
        table.clear().draw();
        if (tconsult == "all") {
            table.rows.add(data.rows).draw();
        }
        else {
            table.rows.add(data).draw();
        }
        closeSpinner('spinnerTable');
        return;
    } else { fconsult = true; }

    table = $('#employeesTable').DataTable({
        data: data.rows,
        columns: [
            { title: 'IdNumber', data: 'IdNumber' },
            { title: 'Name', data: 'Name' },
            { title: 'Surename', data: 'Surename' },
            { title: 'Email', data: 'Email' },
            { title: 'Address', data: 'Address' },
            { title: 'Gender', data: 'Gender' },
            { title: 'Birth Date', data: 'BirthDate' },
            { title: 'Contact Number', data: 'ContactNumber' },
            { title: 'Contract Type', data: 'ContractType' },
            { title: 'Salary', data: 'Salary' },
            { title: 'Anual Salary', data: 'AnualSalary'}
        ],
        select: 'single'
    });
    table.buttons().container()
        .appendTo($('.col-sm-12:eq(0)', table.table().container()));
}

function closeSpinner(name) {
    $("#" + name).addClass('hide');
}

function openSpinner(name) {
    $("#" + name).removeClass('hide');
}