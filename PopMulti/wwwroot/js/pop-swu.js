const popkmuttmulti = document.getElementById('pop-swu-multi');
const btn = document.getElementById('btn-pop-swu');

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
