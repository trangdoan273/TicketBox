var link = document.getElementById('dateClick');

link.addEventListener('click', function(event){
    event.preventDefault();
    
    if(link.classList.contains('default')){
        link.classList.remove('default');
        link.classList.add('clicked');
    } else {
        link.classList.remove('clicked');
        link.classList.add('default');
    }
});