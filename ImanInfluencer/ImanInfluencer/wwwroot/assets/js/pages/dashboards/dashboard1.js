/*
Template Name: Admin Pro Admin
Author: Wrappixel
Email: niravjoshi87@gmail.com
File: js
*/
$(function () {
    "use strict";
    // ==============================================================
    // Newsletter
    // ==============================================================
    var state = document.getElementsByClassName("chartdate");
    var arr = [];
    var state2 = new Map();
    var count = 0;
    var flag = true;
    for (var i = 0; i < state.length; i++) {
        for (var j = 0; j < arr.length; j++) {
            if (arr[j] == state[i].innerHTML) {
                flag = false;
                state2.set(arr[j], state2.get(arr[j]) + 1);
                break;
            }
        }
        if (flag) {
            arr[count] = state[i].innerHTML;
            state2.set(arr[count], 1);
            count++;

        }

        flag = true;

    }

    for (var i = 0; i < arr.length; i++) {
        console.log("tenp is " + state2.get(arr[i]));
    }

    arr.sort();
    var yaxis = [];
    for (var i = 0; i < arr.length; i++) {
        yaxis[i] = state2.get(arr[i]);
        const myArray = arr[i].split(" ");
        arr[i] = myArray[0];
    }
    //ct-visits
    new Chartist.Line('#ct-visits', {

        labels: arr,
        series: [yaxis,

        ]
    }, {
        top: 1,
        low: 0,
        showPoint: true,
        fullWidth: true,
        plugins: [
            Chartist.plugins.tooltip()
        ],
        axisY: {
            labelInterpolationFnc: function (value) {
                return value;
            }
        },
        showArea: true
    });


    var chart = [chart];

    var sparklineLogin = function () {
        $('#sparklinedash').sparkline([0, 5, 6, 10, 9, 12, 4, 9], {
            type: 'bar',
            height: '30',
            barWidth: '4',
            resize: true,
            barSpacing: '5',
            barColor: '#7ace4c'
        });
        $('#sparklinedash2').sparkline([0, 5, 6, 10, 9, 12, 4, 9], {
            type: 'bar',
            height: '30',
            barWidth: '4',
            resize: true,
            barSpacing: '5',
            barColor: '#7460ee'
        });
        $('#sparklinedash3').sparkline([0, 5, 6, 10, 9, 12, 4, 9], {
            type: 'bar',
            height: '30',
            barWidth: '4',
            resize: true,
            barSpacing: '5',
            barColor: '#11a0f8'
        });
        $('#sparklinedash4').sparkline([0, 5, 6, 10, 9, 12, 4, 9], {
            type: 'bar',
            height: '30',
            barWidth: '4',
            resize: true,
            barSpacing: '5',
            barColor: '#f33155'
        });
    }
    var sparkResize;
    $(window).on("resize", function (e) {
        clearTimeout(sparkResize);
        sparkResize = setTimeout(sparklineLogin, 500);
    });
    sparklineLogin();
});
