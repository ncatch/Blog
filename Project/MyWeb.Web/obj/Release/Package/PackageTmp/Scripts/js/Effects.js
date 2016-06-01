function onShow(divs, i, time) {
    if(time == ""){
        time = 500
    }
    $(divs[i]).animate({ opacity: 0.6 }, time, function () {
        $(this).animate({ opacity: 1 }, time);
        onShow(divs, ++i,time)
    });
}