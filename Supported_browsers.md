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
Listings for **Chrome** & **Firefox** include their respective Android versions.

For some time, **Opera browser** has internally used the same rendering engine as Chrome.

### Browserslist query
[BrowsersList] is a mechanism for specifying explicitly supported web browsers. Agiil uses a BrowsersList string to indicate its profile of supported browsers. This query is:

[BrowsersList]: https://github.com/browserslist/browserslist

```
  "browserslist": [
    "> 0.2%",
    "last 2 versions",
    "ChromeAndroid >= 55",
    "Chrome >= 55",
    "Firefox >= 50",
    "FirefoxAndroid >= 50",
    "Edge >= 12",
    "IE >= 9",
    "Opera >= 42",
    "Safari >= 10",
    "Android >= 4.4",
    "iOS >= 10",
    "Node 6",
    "Node 8",
    "Node 10"
  ]
```