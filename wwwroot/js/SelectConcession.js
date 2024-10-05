var button = document.getElementById('bookClick');

button.addEventListener('click', function(){
    if(button.classList.contains('default')){
        button.classList.remove('default');
        button.classList.add('clicked');
    } else {
        button.classList.remove('clicked');
        button.classList.add('default');
    }
}); 

