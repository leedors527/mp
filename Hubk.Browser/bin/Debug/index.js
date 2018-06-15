var page = require('webpage').create();
var system = require('system');

page.settings.loadImages = false;
page.settings.userAgent = system.args[2];
page.settings.localToRemoteUrlAccessEnabled = true;
page.settings.webSecurityEnabled = false;
page.settings.resourceTimeout = 10000;

page.onError = function (msg, trace) {
    return;
};

page.open(system.args[1], function () {
    console.log(page.content);
    phantom.exit();
});
