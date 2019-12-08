
$(function () { 
    $("#btnSave").click(function () {
        document.getElementById('msgEntity').innerHTML = '';
        //alert("");  
        $.ajax({
            type: "POST",
            url: '/Home/GetEntities',
            data: { 'msg': document.getElementById('StudentName').value },
            success: function (data) {
                // alert("Data has been added successfully."); 
                console.log(data);
                document.getElementById('msgEntity').innerHTML = data
            },
            error: function () {
                console.log("Error while inserting data");
            }
        });
        document.getElementById('msgSent').innerHTML = '';
        //alert("");  
        $.ajax({
            type: "POST",
            url: '/Home/GetSentiment',
            data: { 'msg': document.getElementById('StudentName').value },
            success: function (data) {
                // alert("Data has been added successfully."); 
                console.log(data);
                document.getElementById('msgSent').innerHTML = data
            },
            error: function () {
                console.log("Error while inserting data");
            }
        });
        document.getElementById('msgLang').innerHTML = '';
        $.ajax({
            type: "POST",
            url: '/Home/GetLanguage',
            data: { 'msg': document.getElementById('StudentName').value },
            success: function (data) {
                // alert("Data has been added successfully."); 
                console.log(data);
                document.getElementById('msgLang').innerHTML = data
            },
            error: function () {
                console.log("Error while inserting data");
            }
        });
        return false;
    });
});  
var keyTimer = null;
let buffer = [];
let lastKeyTime = Date.now();
let allow = true;
const charListRight = 'jkl;';
charListLeftRight = 'asdfjkl;';
const charListLeft = 'asdf';
var lastBufLen = 0;
let currentTime = Date.now();
const charList = 'abcdefghijklmnopqrstuvwxyz.';
let words = '';
var apiTimer = null;
let sender = null;
let evt = null;
$(document).ready(function () {
    document.getElementById('btn').setAttribute('aria-labelledby', 'StudentName'); 
    keyTimer = null;
    buffer = [];
    lastKeyTime = Date.now();
});

function txtOnKeyUp() {
    if (charListLeftRight.indexOf(evt.key.toLowerCase()) === -1) {
        console.log(evt.key);
        words = sender.value.replace(evt.key, '');
        sender.value = words;
        console.log('invalid key');
        return false;
    }
}

function _txtOnKeyUp() {
    lastBufLen = buffer.length;
    if (charListLeftRight.indexOf(evt.key.toLowerCase()) === -1) {
        console.log('invalid key');
        buffer = [];
        words = sender.value;
        return false;
    }
    if (lastBufLen == 0) return;
    console.log(buffer);
    const key = evt.key.toLowerCase();

    let rgtKey = -1;
    let lftKey = 0;

    for (let idx = 0; idx < lastBufLen; idx++) {
        if (buffer[idx] === 'j')
            rgtKey += 1;
        else if (buffer[idx] === 'k')
            rgtKey  += 2;
        else if (buffer[idx] === 'l')
            rgtKey  += 3;
        else if (buffer[idx] === ';')
            rgtKey  += 4;
        else if (buffer[idx] === 'f')
            lftKey -= 1;
        else if (buffer[idx] === 'd')
            lftKey -= 2;
        else if (buffer[idx] === 's')
            lftKey -= 3;
        else if (buffer[idx] === 'a')
            lftKey -= 4;
    }
    buffer = [];

    let nxtKey = lftKey + rgtKey;
    if (nxtKey < 0)
        nxtKey = charList.length + nxtKey;

    words += charList[nxtKey];
    document.getElementById('curImg').src = '/images/' + charList[nxtKey]+'.jpg'
    sender.value = words;
    setTimeout(() => {
        document.getElementById('btn').focus();
        document.getElementById('StudentName').focus()
    }, 1000);
}


function txtOnKeyPress(s) {
}

function txtOnChange(s) {
}

function txtOnKeyDown(s) {
    sender = s;
    evt = window.event;
    if (charListLeftRight.indexOf(evt.key.toLowerCase()) === -1) {
        console.log('invalid key');
        buffer = [];
        if (words)
            console.log(words)
        return false;
    }

    if (apiTimer)
        clearTimeout(apiTimer);
    apiTimer = setTimeout(_txtOnKeyUp, 1000);

    if (charListLeftRight.indexOf(evt.key.toLowerCase()) !== -1)
        buffer.push(evt.key.toLowerCase());
}
