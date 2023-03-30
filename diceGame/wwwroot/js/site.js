// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.getElementById("btnNewGame").addEventListener('click', () => {

    document.getElementById('playGameForm').action = '/home/index';

});

function ValidatePlayGameForm(e){

    var bet = document.getElementById('bet').value;

    if (bet === '') {

        document.getElementById('message').innerHTML = 'valid bet required';

        e.preventDefault();

    } else if (bet < 1) {
        document.getElementById('message').innerHTML = 'valid bet required';

        e.preventDefault();
    } else if (bet.includes('.')) {

        document.getElementById('message').innerHTML = 'valid bet required';

        e.preventDefault();
    }

}