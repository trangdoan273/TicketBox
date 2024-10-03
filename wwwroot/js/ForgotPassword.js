function openPopUp(){
    document.getElementById('codePopUp').style.display = 'flex';
}

function closePopUp(){
    document.getElementById('codePopUp').style.display = 'none';
}

function submitCode(){
    var code = document.getElementById('verificationCode').value;

    if(!code){
        alert('Vui lòng nhập mã xác thực');
    } else{
        if(code === '123456'){
            alert('Mã xác thực đúng! Bạn có thể đặt lại mật khẩu');
            closePopUp();
        } else {
            alert('Mã xác thực không chính xác');
        }
    }
}
