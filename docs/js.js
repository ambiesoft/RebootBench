
// https://stackoverflow.com/a/16046607
function getQuerystringNameValue(name)
{
    // For example... passing a name parameter of "name1" will return a value of "100", etc.
    // page.htm?name1=100&name2=101&name3=102

    var winURL = window.location.hash;
    var queryStringArray = winURL.split("#");
    var queryStringParamArray = queryStringArray[1].split("&");
    var nameValue = null;

    for ( var i=0; i<queryStringParamArray.length; i++ )
    {           
        queryStringNameValueArray = queryStringParamArray[i].split("=");

        if ( name == queryStringNameValueArray[0] )
        {
            nameValue = queryStringNameValueArray[1];
        }                       
    }

    return nameValue;
}

// https://stackoverflow.com/a/14298178
function timeSince(when) { // this ignores months
    var obj = {};

    // https://stackoverflow.com/a/8047891
    var now = new Date;
    var utc_timestamp = Date.UTC(now.getUTCFullYear(),now.getUTCMonth(), now.getUTCDate() , 
      now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds(), now.getUTCMilliseconds());

    obj._milliseconds = (utc_timestamp).valueOf() - when.valueOf();
    obj.milliseconds = obj._milliseconds % 1000;
    obj._seconds = (obj._milliseconds - obj.milliseconds) / 1000;
    obj.seconds = obj._seconds % 60;
    obj._minutes = (obj._seconds - obj.seconds) / 60;
    obj.minutes = obj._minutes % 60;
    obj._hours = (obj._minutes - obj.minutes) / 60;
    obj.hours = obj._hours % 24;
    obj._days = (obj._hours - obj.hours) / 24;
    obj.days = obj._days % 365;
    // finally
    obj.years = (obj._days - obj.days) / 365;
    return obj;
}
function formatSpan(val)
{
    val = val.toString();
    while(val.length < 2)
    {
        val = "0" + val;
    }
    return val;
}
function calcTime()
{
    let elem = document.getElementById("reboottime");

    let starttime = getQuerystringNameValue("starttime");
    
    let dtstartTime = new Date(0);
    dtstartTime.setUTCMilliseconds(starttime);

    let span = timeSince(dtstartTime);

    elem.innerText = formatSpan(span.hours) + ":" + formatSpan(span.minutes) + ":" + formatSpan( span.seconds);
}   