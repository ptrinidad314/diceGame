// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("btnNewGame").addEventListener('click', () => {

    document.getElementById('playGameForm').action = '/home/index';

    form.submit();
});

document.getElementById('infoIcon').addEventListener('click', () => {

    var displayVal = document.getElementById('infoText').style.display;

    if (displayVal === '' || displayVal === 'none') {
        document.getElementById('infoText').style.display = 'block';
    } else {
        document.getElementById('infoText').style.display = 'none';
    }

});

document.getElementById('btnRoll').addEventListener('click', () => {

    var isValid = ValidatePlayGameForm();

    if (isValid) {

        var dieElems = document.getElementsByClassName('die');

        for (var i = 0; i < dieElems.length; i++) {
            dieElems[i].classList.add('rollDie');
        }

        setTimeout(function () {

            form.submit();

        }, 2000);
    }

    return false;

});


var form = document.getElementById('playGameForm');
form.onsubmit = function () {
    return false;
}




function ValidatePlayGameForm(){

    var isValid = true;

    var bet = document.getElementById('bet').value;
    var balance = document.getElementById('balance').value;

    if (bet === '') {

        document.getElementById('message').innerHTML = 'valid bet required';

        isValid = false;

    } else if (parseInt(bet) < 1) {
        document.getElementById('message').innerHTML = 'valid bet required';

        isValid = false;
    } else if (bet.includes('.')) {

        document.getElementById('message').innerHTML = 'valid bet required';

        isValid = false;

    } else if (parseInt(bet) > parseInt(balance)) {

        document.getElementById('message').innerHTML = "you don't have enough for that bet ";

        isValid = false;

    }

    return isValid;

}