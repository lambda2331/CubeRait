$(document).ready(function() {
    $("#logUser").click(function () {
        var user = {
            "grant_type": "password",
            "userName": $("#Login").val().toString(),
            "password": $("#passwordLog").val().toString()
        }
        $.ajax({
            url: '/Token',
            dataType: 'json',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: user,
            success: function (data) {
                $("#userName").text("Hello " + data.userName);
                localStorage.setItem("token", data.access_token);
            },
            error: function (x, y, z) {
                alert(x.statu + "\n" + y + "\n" + z);
            }
        });
        $('#header').css('display','none');
        $('#userInf').css('display','block');
    });
    
    $("#logOutUser").click(function(){
        $('#header').css('display','block');
        $('#userInf').css('display', 'none');
    });
    
    $("#setUser").click(function(){
        $('#settingsUser').css('display','block');
    });
    $("#saveCube").click(function() {
        var cube = {
            "TypeOfCube": $('#cube').val(),
            "Time": $("#time").val()
        }
        $.ajax({
            url: 'api/User/AddCube',
            dataType: 'json',
            type: 'post',
            headers: {
                "Authorization": 'Bearer ' + localStorage.getItem("token"),
                "Content-Type": 'application/json; charset=UTF-8;'
            },
            data: JSON.stringify(cube),
            success: function (data) {
                alert("Cube save!!!");
                $('#cube').val("");
                $("#time").val("");
            },
            error: function (x, y, z) {
                alert(x.statu + "\n" + y + "\n" + z);
            }
        });
    });
    $("#closeSetting").click(function(){
        $('#settingsUser').css('display','none');
    });
    
    $("#signUser").click(function(){
        $('#regUser').css('display', 'block');
        
    });
    
    $("#signUpUser").click(function () {
        var name = $('#name').val();
        var surname = $('#surname').val();
        var login = $('#loginUser').val();
        var password = $('#password').val();
        var user = {
            "userName": login,
            "firstName": name,
            "secondName": surname,
            "password": password,
            "confirmPassword": password
        }
        $.ajax({
            url: '/api/Account/Register',
            dataType: 'json',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: user,
            success: function (data) {
                alert("Success");
            }
        });
        $('#regUser').css('display','none');
    });

     $("#cube2").click(function () {
         $.ajax({
             url: '/api/Rait',
             type: 'GET',
             dataType: "json",
             success: function (data) {
                 var result = "<table><th>Cube</th><th>Name</th><th>Time</th><th>Country</th>";
                 $.each(data, function (index, num) {
                     result += "<tr><td>" + num.UserRaiting.TypeOfCube + "</td><td>" + num.Name + " " + num.Surname + "</td><td>" + num.UserRaiting.Time + "</td><td>" + num.Country + "</td></tr>";
                 });
                 result += "</table>";
                 $("#tableRaiting").html(result);
             },
             error: function (x, y, z) {
                 alert(x + "\n" + y + "\n" + z);
             }
         });
     });

     $("#cube3").click(function () {
         var i = 1;
         $.ajax({
             url: '/api/Rait/3',
             type: 'GET',
             dataType: "json",
             success: function (data) {
                 var result = "<table><th>Raiting</th><th>Name</th><th>Time</th>";
                 $.each(data, function (index, num) {
                     result += "<tr><td>" + i + "</td><td>" + num.userName + "</td><td>" + num.time + "</td></tr>";
                 });
                 result += "</table>";
                 $("#tableRaiting").html(result);
             },
             error: function (x, y, z) {
                 alert(x + "\n" + y + "\n" + z);
             }
         });
     });

     $("#cube4").click(function () {
         $.ajax({
             url: '/api/Rait/4',
             type: 'GET',
             dataType: "json",
             success: function (data) {
                 var result = "<table><th>Raiting</th><th>Name</th><th>Time</th><th>Country</th>";
                 $.each(data, function (index, num) {
                     result += "<tr><td>" + num.raitingUser.raiting + "</td><td>" + num.name + " " + num.surname + "</td><td>" + num.raitingUser.cube4 + "</td><td>" + num.country + "</td></tr>";
                 });
                 result += "</table>";
                 $("#tableRaiting").html(result);
             },
             error: function (x, y, z) {
                 alert(x + "\n" + y + "\n" + z);
             }
         });
     });

     $("#cube5").click(function () {
         $.ajax({
             url: '/api/Rait/5',
             type: 'GET',
             dataType: "json",
             success: function (data) {
                 var result = "<table><th>Raiting</th><th>Name</th><th>Time</th><th>Country</th>";
                 $.each(data, function (index, num) {
                     result += "<tr><td>" + num.UserRaiting.raiting + "</td><td>" + num.name + " " + num.surname + "</td><td>" + num.UserRaiting.cube5 + "</td><td>" + num.country + "</td></tr>";
                 });
                 result += "</table>";
                 $("#tableRaiting").html(result);
             },
             error: function (x, y, z) {
                 alert(x + "\n" + y + "\n" + z);
             }
         });
     });

     $("#cube6").click(function () {
         $.ajax({
             url: '/api/Rait/6',
             type: 'GET',
             dataType: "json",
             success: function (data) {
                 var result = "<table><th>Raiting</th><th>Name</th><th>Time</th><th>Country</th>";
                 $.each(data, function (index, num) {
                     result += "<tr><td>" + num.raitingUser.raiting + "</td><td>" + num.name + " " + num.surname + "</td><td>" + num.raitingUser.cube6 + "</td><td>" + num.country + "</td></tr>";
                 });
                 result += "</table>";
                 $("#tableRaiting").html(result);
             },
             error: function (x, y, z) {
                 alert(x + "\n" + y + "\n" + z);
             }
         });
     });

     $("cube7").click(function () {
         $.ajax({
             url: '/api/Rait/7',
             type: 'GET',
             dataType: "json",
             success: function (data) {
                 var result = "<table><th>Raiting</th><th>Name</th><th>Time</th><th>Country</th>";
                 $.each(data, function (index, num) {
                     result += "<tr><td>" + num.raitingUser.raiting + "</td><td>" + num.name + " " + num.surname + "</td><td>" + num.raitingUser.cube7 + "</td><td>" + num.country + "</td></tr>";
                 });
                 result += "</table>";
                 $("#tableRaiting").html(result);
             },
             error: function (x, y, z) {
                 alert(x + "\n" + y + "\n" + z);
             }
         });
     });
});
    