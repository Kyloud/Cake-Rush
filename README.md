<html><head><meta http-equiv="Content-Type" content="text/html; charset=utf-8"/><title>Cake Rush</title><style>
/* cspell:disable-file */
/* webkit printing magic: print all background colors */
html {
	-webkit-print-color-adjust: exact;
}
* {
	box-sizing: border-box;
	-webkit-print-color-adjust: exact;
}

html,
body {
	margin: 0;
	padding: 0;
}
@media only screen {
	body {
		margin: 2em auto;
		max-width: 900px;
		color: rgb(55, 53, 47);
	}
}

body {
	line-height: 1.5;
	white-space: pre-wrap;
}

a,
a.visited {
	color: inherit;
	text-decoration: underline;
}

.pdf-relative-link-path {
	font-size: 80%;
	color: #444;
}

h1,
h2,
h3 {
	letter-spacing: -0.01em;
	line-height: 1.2;
	font-weight: 600;
	margin-bottom: 0;
}

.page-title {
	font-size: 2.5rem;
	font-weight: 700;
	margin-top: 0;
	margin-bottom: 0.75em;
}

h1 {
	font-size: 1.875rem;
	margin-top: 1.875rem;
}

h2 {
	font-size: 1.5rem;
	margin-top: 1.5rem;
}

h3 {
	font-size: 1.25rem;
	margin-top: 1.25rem;
}

.source {
	border: 1px solid #ddd;
	border-radius: 3px;
	padding: 1.5em;
	word-break: break-all;
}

.callout {
	border-radius: 3px;
	padding: 1rem;
}

figure {
	margin: 1.25em 0;
	page-break-inside: avoid;
}

figcaption {
	opacity: 0.5;
	font-size: 85%;
	margin-top: 0.5em;
}

mark {
	background-color: transparent;
}

.indented {
	padding-left: 1.5em;
}

hr {
	background: transparent;
	display: block;
	width: 100%;
	height: 1px;
	visibility: visible;
	border: none;
	border-bottom: 1px solid rgba(55, 53, 47, 0.09);
}

img {
	max-width: 100%;
}

@media only print {
	img {
		max-height: 100vh;
		object-fit: contain;
	}
}

@page {
	margin: 1in;
}

.collection-content {
	font-size: 0.875rem;
}

.column-list {
	display: flex;
	justify-content: space-between;
}

.column {
	padding: 0 1em;
}

.column:first-child {
	padding-left: 0;
}

.column:last-child {
	padding-right: 0;
}

.table_of_contents-item {
	display: block;
	font-size: 0.875rem;
	line-height: 1.3;
	padding: 0.125rem;
}

.table_of_contents-indent-1 {
	margin-left: 1.5rem;
}

.table_of_contents-indent-2 {
	margin-left: 3rem;
}

.table_of_contents-indent-3 {
	margin-left: 4.5rem;
}

.table_of_contents-link {
	text-decoration: none;
	opacity: 0.7;
	border-bottom: 1px solid rgba(55, 53, 47, 0.18);
}

table,
th,
td {
	border: 1px solid rgba(55, 53, 47, 0.09);
	border-collapse: collapse;
}

table {
	border-left: none;
	border-right: none;
}

th,
td {
	font-weight: normal;
	padding: 0.25em 0.5em;
	line-height: 1.5;
	min-height: 1.5em;
	text-align: left;
}

th {
	color: rgba(55, 53, 47, 0.6);
}

ol,
ul {
	margin: 0;
	margin-block-start: 0.6em;
	margin-block-end: 0.6em;
}

li > ol:first-child,
li > ul:first-child {
	margin-block-start: 0.6em;
}

ul > li {
	list-style: disc;
}

ul.to-do-list {
	text-indent: -1.7em;
}

ul.to-do-list > li {
	list-style: none;
}

.to-do-children-checked {
	text-decoration: line-through;
	opacity: 0.375;
}

ul.toggle > li {
	list-style: none;
}

ul {
	padding-inline-start: 1.7em;
}

ul > li {
	padding-left: 0.1em;
}

ol {
	padding-inline-start: 1.6em;
}

ol > li {
	padding-left: 0.2em;
}

.mono ol {
	padding-inline-start: 2em;
}

.mono ol > li {
	text-indent: -0.4em;
}

.toggle {
	padding-inline-start: 0em;
	list-style-type: none;
}

/* Indent toggle children */
.toggle > li > details {
	padding-left: 1.7em;
}

.toggle > li > details > summary {
	margin-left: -1.1em;
}

.selected-value {
	display: inline-block;
	padding: 0 0.5em;
	background: rgba(206, 205, 202, 0.5);
	border-radius: 3px;
	margin-right: 0.5em;
	margin-top: 0.3em;
	margin-bottom: 0.3em;
	white-space: nowrap;
}

.collection-title {
	display: inline-block;
	margin-right: 1em;
}

.simple-table {
	margin-top: 1em;
	font-size: 0.875rem;
	empty-cells: show;
}
.simple-table td {
	height: 29px;
	min-width: 120px;
}

.simple-table th {
	height: 29px;
	min-width: 120px;
}

.simple-table-header-color {
	background: rgb(247, 246, 243);
	color: black;
}
.simple-table-header {
	font-weight: 500;
}

time {
	opacity: 0.5;
}

.icon {
	display: inline-block;
	max-width: 1.2em;
	max-height: 1.2em;
	text-decoration: none;
	vertical-align: text-bottom;
	margin-right: 0.5em;
}

img.icon {
	border-radius: 3px;
}

.user-icon {
	width: 1.5em;
	height: 1.5em;
	border-radius: 100%;
	margin-right: 0.5rem;
}

.user-icon-inner {
	font-size: 0.8em;
}

.text-icon {
	border: 1px solid #000;
	text-align: center;
}

.page-cover-image {
	display: block;
	object-fit: cover;
	width: 100%;
	max-height: 30vh;
}

.page-header-icon {
	font-size: 3rem;
	margin-bottom: 1rem;
}

.page-header-icon-with-cover {
	margin-top: -0.72em;
	margin-left: 0.07em;
}

.page-header-icon img {
	border-radius: 3px;
}

.link-to-page {
	margin: 1em 0;
	padding: 0;
	border: none;
	font-weight: 500;
}

p > .user {
	opacity: 0.5;
}

td > .user,
td > time {
	white-space: nowrap;
}

input[type="checkbox"] {
	transform: scale(1.5);
	margin-right: 0.6em;
	vertical-align: middle;
}

p {
	margin-top: 0.5em;
	margin-bottom: 0.5em;
}

.image {
	border: none;
	margin: 1.5em 0;
	padding: 0;
	border-radius: 0;
	text-align: center;
}

.code,
code {
	background: rgba(135, 131, 120, 0.15);
	border-radius: 3px;
	padding: 0.2em 0.4em;
	border-radius: 3px;
	font-size: 85%;
	tab-size: 2;
}

code {
	color: #eb5757;
}

.code {
	padding: 1.5em 1em;
}

.code-wrap {
	white-space: pre-wrap;
	word-break: break-all;
}

.code > code {
	background: none;
	padding: 0;
	font-size: 100%;
	color: inherit;
}

blockquote {
	font-size: 1.25em;
	margin: 1em 0;
	padding-left: 1em;
	border-left: 3px solid rgb(55, 53, 47);
}

.bookmark {
	text-decoration: none;
	max-height: 8em;
	padding: 0;
	display: flex;
	width: 100%;
	align-items: stretch;
}

.bookmark-title {
	font-size: 0.85em;
	overflow: hidden;
	text-overflow: ellipsis;
	height: 1.75em;
	white-space: nowrap;
}

.bookmark-text {
	display: flex;
	flex-direction: column;
}

.bookmark-info {
	flex: 4 1 180px;
	padding: 12px 14px 14px;
	display: flex;
	flex-direction: column;
	justify-content: space-between;
}

.bookmark-image {
	width: 33%;
	flex: 1 1 180px;
	display: block;
	position: relative;
	object-fit: cover;
	border-radius: 1px;
}

.bookmark-description {
	color: rgba(55, 53, 47, 0.6);
	font-size: 0.75em;
	overflow: hidden;
	max-height: 4.5em;
	word-break: break-word;
}

.bookmark-href {
	font-size: 0.75em;
	margin-top: 0.25em;
}

.sans { font-family: ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol"; }
.code { font-family: "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace; }
.serif { font-family: Lyon-Text, Georgia, ui-serif, serif; }
.mono { font-family: iawriter-mono, Nitti, Menlo, Courier, monospace; }
.pdf .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK JP'; }
.pdf:lang(zh-CN) .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK SC'; }
.pdf:lang(zh-TW) .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK TC'; }
.pdf:lang(ko-KR) .sans { font-family: Inter, ui-sans-serif, -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, "Apple Color Emoji", Arial, sans-serif, "Segoe UI Emoji", "Segoe UI Symbol", 'Twemoji', 'Noto Color Emoji', 'Noto Sans CJK KR'; }
.pdf .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK JP'; }
.pdf:lang(zh-CN) .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK SC'; }
.pdf:lang(zh-TW) .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK TC'; }
.pdf:lang(ko-KR) .code { font-family: Source Code Pro, "SFMono-Regular", Menlo, Consolas, "PT Mono", "Liberation Mono", Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK KR'; }
.pdf .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK JP'; }
.pdf:lang(zh-CN) .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK SC'; }
.pdf:lang(zh-TW) .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK TC'; }
.pdf:lang(ko-KR) .serif { font-family: PT Serif, Lyon-Text, Georgia, ui-serif, serif, 'Twemoji', 'Noto Color Emoji', 'Noto Serif CJK KR'; }
.pdf .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK JP'; }
.pdf:lang(zh-CN) .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK SC'; }
.pdf:lang(zh-TW) .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK TC'; }
.pdf:lang(ko-KR) .mono { font-family: PT Mono, iawriter-mono, Nitti, Menlo, Courier, monospace, 'Twemoji', 'Noto Color Emoji', 'Noto Sans Mono CJK KR'; }
.highlight-default {
	color: rgba(55, 53, 47, 1);
}
.highlight-gray {
	color: rgba(120, 119, 116, 1);
	fill: rgba(120, 119, 116, 1);
}
.highlight-brown {
	color: rgba(159, 107, 83, 1);
	fill: rgba(159, 107, 83, 1);
}
.highlight-orange {
	color: rgba(217, 115, 13, 1);
	fill: rgba(217, 115, 13, 1);
}
.highlight-yellow {
	color: rgba(203, 145, 47, 1);
	fill: rgba(203, 145, 47, 1);
}
.highlight-teal {
	color: rgba(68, 131, 97, 1);
	fill: rgba(68, 131, 97, 1);
}
.highlight-blue {
	color: rgba(51, 126, 169, 1);
	fill: rgba(51, 126, 169, 1);
}
.highlight-purple {
	color: rgba(144, 101, 176, 1);
	fill: rgba(144, 101, 176, 1);
}
.highlight-pink {
	color: rgba(193, 76, 138, 1);
	fill: rgba(193, 76, 138, 1);
}
.highlight-red {
	color: rgba(212, 76, 71, 1);
	fill: rgba(212, 76, 71, 1);
}
.highlight-gray_background {
	background: rgba(241, 241, 239, 1);
}
.highlight-brown_background {
	background: rgba(244, 238, 238, 1);
}
.highlight-orange_background {
	background: rgba(251, 236, 221, 1);
}
.highlight-yellow_background {
	background: rgba(251, 243, 219, 1);
}
.highlight-teal_background {
	background: rgba(237, 243, 236, 1);
}
.highlight-blue_background {
	background: rgba(231, 243, 248, 1);
}
.highlight-purple_background {
	background: rgba(244, 240, 247, 0.8);
}
.highlight-pink_background {
	background: rgba(249, 238, 243, 0.8);
}
.highlight-red_background {
	background: rgba(253, 235, 236, 1);
}
.block-color-default {
	color: inherit;
	fill: inherit;
}
.block-color-gray {
	color: rgba(120, 119, 116, 1);
	fill: rgba(120, 119, 116, 1);
}
.block-color-brown {
	color: rgba(159, 107, 83, 1);
	fill: rgba(159, 107, 83, 1);
}
.block-color-orange {
	color: rgba(217, 115, 13, 1);
	fill: rgba(217, 115, 13, 1);
}
.block-color-yellow {
	color: rgba(203, 145, 47, 1);
	fill: rgba(203, 145, 47, 1);
}
.block-color-teal {
	color: rgba(68, 131, 97, 1);
	fill: rgba(68, 131, 97, 1);
}
.block-color-blue {
	color: rgba(51, 126, 169, 1);
	fill: rgba(51, 126, 169, 1);
}
.block-color-purple {
	color: rgba(144, 101, 176, 1);
	fill: rgba(144, 101, 176, 1);
}
.block-color-pink {
	color: rgba(193, 76, 138, 1);
	fill: rgba(193, 76, 138, 1);
}
.block-color-red {
	color: rgba(212, 76, 71, 1);
	fill: rgba(212, 76, 71, 1);
}
.block-color-gray_background {
	background: rgba(241, 241, 239, 1);
}
.block-color-brown_background {
	background: rgba(244, 238, 238, 1);
}
.block-color-orange_background {
	background: rgba(251, 236, 221, 1);
}
.block-color-yellow_background {
	background: rgba(251, 243, 219, 1);
}
.block-color-teal_background {
	background: rgba(237, 243, 236, 1);
}
.block-color-blue_background {
	background: rgba(231, 243, 248, 1);
}
.block-color-purple_background {
	background: rgba(244, 240, 247, 0.8);
}
.block-color-pink_background {
	background: rgba(249, 238, 243, 0.8);
}
.block-color-red_background {
	background: rgba(253, 235, 236, 1);
}
.select-value-color-pink { background-color: rgba(245, 224, 233, 1); }
.select-value-color-purple { background-color: rgba(232, 222, 238, 1); }
.select-value-color-green { background-color: rgba(219, 237, 219, 1); }
.select-value-color-gray { background-color: rgba(227, 226, 224, 1); }
.select-value-color-opaquegray { background-color: rgba(255, 255, 255, 0.0375); }
.select-value-color-orange { background-color: rgba(250, 222, 201, 1); }
.select-value-color-brown { background-color: rgba(238, 224, 218, 1); }
.select-value-color-red { background-color: rgba(255, 226, 221, 1); }
.select-value-color-yellow { background-color: rgba(253, 236, 200, 1); }
.select-value-color-blue { background-color: rgba(211, 229, 239, 1); }

.checkbox {
	display: inline-flex;
	vertical-align: text-bottom;
	width: 16;
	height: 16;
	background-size: 16px;
	margin-left: 2px;
	margin-right: 5px;
}

.checkbox-on {
	background-image: url("data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%2216%22%20height%3D%2216%22%20viewBox%3D%220%200%2016%2016%22%20fill%3D%22none%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%3E%0A%3Crect%20width%3D%2216%22%20height%3D%2216%22%20fill%3D%22%2358A9D7%22%2F%3E%0A%3Cpath%20d%3D%22M6.71429%2012.2852L14%204.9995L12.7143%203.71436L6.71429%209.71378L3.28571%206.2831L2%207.57092L6.71429%2012.2852Z%22%20fill%3D%22white%22%2F%3E%0A%3C%2Fsvg%3E");
}

.checkbox-off {
	background-image: url("data:image/svg+xml;charset=UTF-8,%3Csvg%20width%3D%2216%22%20height%3D%2216%22%20viewBox%3D%220%200%2016%2016%22%20fill%3D%22none%22%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%3E%0A%3Crect%20x%3D%220.75%22%20y%3D%220.75%22%20width%3D%2214.5%22%20height%3D%2214.5%22%20fill%3D%22white%22%20stroke%3D%22%2336352F%22%20stroke-width%3D%221.5%22%2F%3E%0A%3C%2Fsvg%3E");
}
	
</style></head><body><article id="6b3c1f6d-4b82-4b87-ab5a-540db506ab1a" class="page sans"><header><div class="page-header-icon undefined"><span class="icon">🎂</span></div><h1 class="page-title">Cake Rush</h1></header><div class="page-body"><h3 id="b9219af5-70c2-4653-947f-a4becfbc1453" class="">[CapStone Information]</h3><figure id="5a693aa1-f941-4bb8-85aa-46d5c24a944b" class="link-to-page"><a href="https://www.notion.so/Cake-Rush-INFO-5a693aa1f9414bb885aa46d5c24a944b">Cake Rush INFO</a></figure><figure id="1fadb2d1-3203-4d15-9d08-b5bfb9b5f3f7" class="link-to-page"><a href="https://www.notion.so/Cake-Rush-InGameStory-1fadb2d132034d159d08b5bfb9b5f3f7">Cake Rush InGameStory</a></figure><figure id="ea3014bf-d72b-4e2c-926c-7595f8b98a5d" class="link-to-page"><a href="https://www.notion.so/CakeRush-Objection-ea3014bfd72b4e2c926c7595f8b98a5d">CakeRush Objection</a></figure><figure id="d5814692-2a8a-48e1-999e-d3b4576d3c36" class="link-to-page"><a href="https://www.notion.so/Cake-Rush-Rules-d58146922a8a48e1999ed3b4576d3c36">Cake Rush Rules</a></figure><figure id="8e5763e2-9df7-4237-a388-acf47570002f" class="link-to-page"><a href="https://www.notion.so/CakeRush-Balancing-8e5763e29df74237a388acf47570002f">CakeRush Balancing</a></figure><figure id="ff1bde19-37b3-47ab-9fdd-f0747e8a76fe" class="link-to-page"><a href="https://www.notion.so/Cake-Rush-Update-Log-ff1bde1937b347ab9fddf0747e8a76fe">Cake Rush Update Log</a></figure><ul id="6f5dd47c-b3a1-42e7-b255-f13abd3c0e86" class="toggle"><li><details open=""><summary><code><mark class="highlight-red_background"><strong>시우 외 접근 금지 (개인적으로 만든 기획 양식 템플릿임)</strong></mark></code></summary><h3 id="afdcd596-74bd-41cf-af28-91f0ed2f5fac" class="">게임 시스템 기획</h3><ul id="25238690-bbed-4d1b-b32a-38da2a208176" class="bulleted-list"><li style="list-style-type:disc">기능적인 것 정하기 - (Ex. 조작 방식, 설정 기능 정하기, 게임 저장 방식)<figure id="cbfc13ed-45f4-4547-8a21-246c20932eed" class="link-to-page"><a href="https://www.notion.so/Contingency-Conception-cbfc13ed45f445478a21246c20932eed">Contingency Conception</a></figure></li></ul><ul id="41a9cbd1-8401-492d-a0d8-f9ae2474e191" class="bulleted-list"><li style="list-style-type:disc">게임 장르 정하기 - (Ex. 액션 어드벤처, Like 장르)<figure id="e1f322f6-db4e-43ed-93d1-72a9d1ca662b" class="link-to-page"><a href="https://www.notion.so/Inspiration-of-Contingency-e1f322f6db4e43ed93d172a9d1ca662b">Inspiration of Contingency</a></figure><figure id="a63c282e-ff73-4912-b06a-a2d256b953c7" class="link-to-page"><a href="https://www.notion.so/Contingency-Genre-Tag-a63c282eff734912b06aa2d256b953c7">Contingency Genre / Tag</a></figure></li></ul><ul id="e5e60afb-43a9-4682-ad26-8bdc4d140568" class="bulleted-list"><li style="list-style-type:disc">게임 규칙과 UI 정하기 - (Ex. 게임오버 조건, 게임 방법)<figure id="6ab370e7-1bed-4637-8e17-ddbdd00e6487" class="link-to-page"><a href="https://www.notion.so/Contingency-UX-6ab370e71bed46378e17ddbdd00e6487">Contingency UX</a></figure></li></ul><ul id="64ae8904-dab1-4701-909c-290e0212b91c" class="bulleted-list"><li style="list-style-type:disc">동작하는 기능(기믹) 정의 - (Ex. 희생자, 수면)<figure id="d0303d1a-127d-451a-be77-a790b118821c" class="link-to-page"><a href="https://www.notion.so/Contingency-Gimmick-d0303d1a127d451abe77a790b118821c">Contingency Gimmick</a></figure></li></ul><ul id="78448126-754e-4e0d-9881-66cb75583f73" class="bulleted-list"><li style="list-style-type:disc">기능이 동작할 때 필요한 코드 구조를 짜기 - (Ex. 스크립트명 및 변수 이름 통합하기)<figure id="73df8bc8-2135-40ec-8fe6-a083e9589ba7" class="link-to-page"><a href="https://www.notion.so/Contingency-Algorithm-73df8bc8213540ec8fe6a083e9589ba7">Contingency Algorithm</a></figure></li></ul><ul id="e0484a0c-3db7-4b98-ba01-0aaa530c93d7" class="bulleted-list"><li style="list-style-type:disc">컨텐츠가 등장하는 패턴 타입을 짜는것 - (Ex. 희생자 등장, 대화 이벤트, 이스터 에그)<figure id="e75419db-1980-407c-8718-af8600e49775" class="link-to-page"><a href="https://www.notion.so/Contingency-Contents-Diagram-e75419db1980407c8718af8600e49775">Contingency Contents Diagram</a></figure></li></ul><hr id="24b72b7f-43ed-4ced-a274-4081ac7f4644"/><h3 id="77bd73f3-f094-4595-b18f-9d1bcabdbd4c" class="">게임 컨텐츠 기획</h3><ul id="62046923-8b7f-44bf-a019-2bc424581f34" class="bulleted-list"><li style="list-style-type:disc">게임의 이야기 정하기 (Ex. 세계관, 인 게임 스토리)<figure id="e10f057e-0b27-4805-a134-f02baa1c83e2" class="link-to-page"><a href="https://www.notion.so/Contingency-WorldView-e10f057e0b274805a134f02baa1c83e2">Contingency WorldView</a></figure></li></ul><ul id="9b8c8b9b-6afb-4cf9-b5c5-6b52e8781e4f" class="bulleted-list"><li style="list-style-type:disc">게임 진행 형식 타입에 맞춰서 목적 및 목표 만들어내기</li></ul><ul id="6b7e640f-e69d-4035-af83-73de0a709fbe" class="bulleted-list"><li style="list-style-type:disc">게임에 규칙과 기믹들을 설명하는 정보를 만들어내기<figure id="1a27c114-d080-4ef8-8080-afffdab86497" class="link-to-page"><a href="https://www.notion.so/Contingency-Tutorial-1a27c114d0804ef88080afffdab86497">Contingency Tutorial</a></figure></li></ul><ul id="935bec97-c095-421b-8752-2eec7bcad7ac" class="bulleted-list"><li style="list-style-type:disc">희생자(괴물) 설정 기획</li></ul><ul id="df692b2c-c322-497a-bfac-bbfc79b5b146" class="bulleted-list"><li style="list-style-type:disc">게임의 대사를 스토리에 녹이기<figure id="5ab07a23-88c1-4b0e-aca4-bac1f230e02f" class="link-to-page"><a href="https://www.notion.so/Contingency-StroyChat-5ab07a2388c14b0eaca4bac1f230e02f">Contingency StroyChat</a></figure></li></ul><ul id="ab317250-44dd-4780-9c97-23d3c1253af1" class="bulleted-list"><li style="list-style-type:disc">다양한 콘텐츠 만들기 (Ex. 개체 공격 도감, 유물, 코스튬, OST, 아트워크)<figure id="514def3c-f588-420e-a39e-cb4c614dcead" class="link-to-page"><a href="https://www.notion.so/Contingency-Contents-514def3cf588420ea39ecb4c614dcead">Contingency Contents</a></figure><figure id="ccc4c82d-1b01-4ec0-8bc0-1d94d9e2e810" class="link-to-page"><a href="https://www.notion.so/Contingency-Artwork-ccc4c82d1b014ec08bc01d94d9e2e810">Contingency Artwork</a></figure><figure id="9147881d-8844-480f-bba9-18829ec8a9ba" class="link-to-page"><a href="https://www.notion.so/Contingency-Music-9147881d8844480fbba918829ec8a9ba">Contingency Music</a></figure></li></ul><hr id="99c5ef07-f458-4cbf-a075-9a052898b124"/><h3 id="3c88ea44-6fa3-4ac5-b5c5-16d5efd8ac24" class="">개발 과정</h3><ul id="39f0d233-d90c-43d8-bc9c-cf95f5f3d796" class="bulleted-list"><li style="list-style-type:disc"><strong>개발 노트</strong><figure id="d31881a1-bbcd-49ec-bfb8-b82df8882c09" class="link-to-page"><a href="https://www.notion.so/2022-04-02-d31881a1bbcd49ecbfb8b82df8882c09">[2022-04-02]</a></figure><figure id="9e9f38d9-51f0-449e-a436-d04c7d7dab1b" class="link-to-page"><a href="https://www.notion.so/2022-04-03-9e9f38d951f0449ea436d04c7d7dab1b">[2022-04-03]</a></figure><figure id="e60b3189-949e-44f8-9753-2180aa2a754c" class="link-to-page"><a href="https://www.notion.so/2022-04-05-e60b3189949e44f897532180aa2a754c">[2022-04-05]</a></figure></li></ul><ul id="7904bfa6-9df4-43ef-867e-6803f2f26fb3" class="bulleted-list"><li style="list-style-type:disc"><strong>코드 노트</strong><figure id="cdff1bf3-faa1-4ac8-a6a9-f441efac544c" class="link-to-page"><a href="https://www.notion.so/Ex-GameManager-cdff1bf3faa14ac8a6a9f441efac544c">Ex. GameManager</a></figure><figure id="8b3c4f5f-3e5a-40ae-97d9-df2444c8ddcb" class="link-to-page"><a href="https://www.notion.so/C-8b3c4f5f3e5a40ae97d9df2444c8ddcb">C# 스크립트를 추가해주세요 </a></figure><figure id="392e864a-dfff-4ca5-99d0-5008d3364072" class="link-to-page"><a href="https://www.notion.so/C-1-392e864adfff4ca599d05008d3364072">C# 스크립트를 추가해주세요 (1)</a></figure><figure id="a250a298-6af4-44ad-a849-c1a6e61055f5" class="link-to-page"><a href="https://www.notion.so/C-1-a250a2986af444ada849c1a6e61055f5">C# 스크립트를 추가해주세요 (1)</a></figure><figure id="59b0f084-c282-488e-b0f3-6a9c96e0cd8d" class="link-to-page"><a href="https://www.notion.so/C-1-59b0f084c282488eb0f36a9c96e0cd8d">C# 스크립트를 추가해주세요 (1)</a></figure></li></ul><hr id="aef5dfff-f2b8-4956-bf8f-ada36f36a42f"/><p id="015f3a43-9ad8-46a0-9dd0-ba385d78ed12" class="">
</p></details></li></ul><hr id="c3fb56de-9ca0-4168-b345-0e73dca8c1a1"/><blockquote id="a7f8b58a-7a43-4edc-8c4a-2664a1182816" class=""><strong>[편집 가능 페이지]</strong><figure id="8216584f-d072-4cb7-af37-dcb7bbe64efb" class="link-to-page"><a href="https://www.notion.so/Development-Notes-8216584fd0724cb7af37dcb7bbe64efb"><span class="icon">🛠️</span>[Development Notes]</a></figure><figure id="b751bb0d-d649-4b47-bb13-f51440a889df" class="link-to-page"><a href="https://www.notion.so/Program-Design-b751bb0dd6494b47bb13f51440a889df"><span class="icon">📋</span>[Program Design]</a></figure></blockquote></div></article></body></html>
