const popkmuttmulti = document.getElementById('pop-kmutt-multi');
const btn = document.getElementById('btn-pop-kmutt');

const openMouthImg = "/pic/pop-open.png";
const closeMouthImg = "/pic/pop-close.png";

btn.addEventListener('mousedown', openMouth);
btn.addEventListener('mouseup', closeMouth);

function openMouth() {
    popkmuttmulti.src = openMouthImg;
}

function closeMouth() {
    popkmuttmulti.src = closeMouthImg;
}
