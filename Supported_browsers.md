# Minimum supported browsers
The Agiil application is a web application which uses a number of modern technologies. Some of these technologies won't work on very old web browsers.

## Minimum supported versions
| Name              | Min version  |
| ----------------- | ------------ |
| Chrome            | 55           |
| Firefox           | 50           |
| Safari (desktop)  | 10           |
| Safari (iOS)      | 10           |
| Internet Explorer | 9            |
| Microsoft Edge    | 12           |
| Android browser   | 4.4 (KitKat) |
| Opera             | 42           |

### Notes
* Listings for **Chrome** & **Firefox** include their respective Android versions.
* **Internet Explorer 9** *might suffer from degraded performance and some non-critical features might be absent*.

### Browserslist query
[BrowsersList] is a mechanism for specifying explicitly supported web browsers.  Those explicitly supported web browsers (in the table above) are represented by BrowsersList query string which follows below.  A visualisation of this is available via [the browserl.ist website].  Please note that many other browsers (particularly those which are based upon Chromium) will also work with Agiil.  The list below indicates the minimum/baseline level for explicit support.

```
chrome >= 55, firefox >= 50, ie >= 9, safari >= 10, edge >= 12, ChromeAndroid >= 55, FirefoxAndroid >= 50, ios >= 10, opera >= 42, Android >= 4.4
```

[BrowsersList]: https://github.com/browserslist/browserslist
[the browserl.ist website]: https://browserl.ist/?q=chrome+%3E%3D+55%2C+firefox+%3E%3D+50%2C+ie+%3E%3D+9%2C+safari+%3E%3D+10%2C+edge+%3E%3D+12%2C+ChromeAndroid+%3E%3D+55%2C+FirefoxAndroid+%3E%3D+50%2C+ios+%3E%3D+10%2C+opera+%3E%3D+42%2C+Android+%3E%3D+4.4
