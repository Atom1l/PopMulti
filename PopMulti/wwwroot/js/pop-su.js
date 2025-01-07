const popsumulti = document.getElementById('pop-su-multi');
const btn = document.getElementById('btn-pop-su');

const openMouthImg = "/pic/pop-open.png";
const closeMouthImg = "/pic/pop-close.png";

btn.addEventListener('mousedown', openMouth);
btn.addEventListener('mouseup', closeMouth);

function openMouth() {
    popsumulti.src = openMouthImg;
}

function closeMouth() {
    popsumulti.src = closeMouthImg;
}
