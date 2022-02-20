let position = 0;
const slidesToShow = 1;
const slidesToScroll = 1;
const container = document.querySelector('.slider-container');
const track = document.querySelector('.slider-track');
const btnPrev = document.querySelector('.btn-prev');
const btnNext = document.querySelector('.btn-next');
const items = document.querySelectorAll('.slider-item');
const itemsCount = items.length;
const itemWidth = container.clientWidth / slidesToShow;
const movePosition = slidesToScroll * itemWidth;
const circleWrap = document.getElementById('circle-wrap');

const circles = {};

for (let i = 1; i <= items.length; i++) {
    circles[`circle${i}`] = document.createElement('div');
    circles[`circle${i}`].setAttribute('class', 'circle');
    circleWrap.appendChild(circles[`circle${i}`]);
}

items.forEach((item) => {
    item.style.minWidth = `${itemWidth}px`;
});

btnNext.addEventListener('click', () => {
    const itemsLeft = itemsCount - (Math.abs(position) + slidesToShow * itemWidth) / itemWidth;

    position -= itemsLeft >= slidesToScroll ? movePosition : itemsLeft * itemWidth;

    setPosition();
    checkBtns();
});

btnPrev.addEventListener('click', () => {
    const itemsLeft = Math.abs(position) / itemWidth;

    position += itemsLeft >= slidesToScroll ? movePosition : itemsLeft * itemWidth;

    setPosition();
    checkBtns();
});

const setPosition = () => {
    track.style.transform = `translateX(${position}px)`;
};

const checkBtns = () => {
    if (position === 0) {
        btnPrev.classList.add('disabled');
    }
    else {
        btnPrev.classList.remove('disabled');
    }
    if (position <= -(itemsCount - slidesToShow) * itemWidth) {
        btnNext.classList.add('disabled');
    }
    else {
        btnNext.classList.remove('disabled');
    }
    let ind = Math.abs(position) / itemWidth + 1;
    if (ind !== 1 && circles[`circle${ind - 1}`].classList.contains('blue')) {
        circles[`circle${ind - 1}`].classList.remove('blue');
    }
    if (ind !== Object.keys(circles).length && circles[`circle${ind + 1}`].classList.contains('blue')) {
        circles[`circle${ind + 1}`].classList.remove('blue');
    }
    circles[`circle${ind}`].classList.add('blue');
};



checkBtns();

