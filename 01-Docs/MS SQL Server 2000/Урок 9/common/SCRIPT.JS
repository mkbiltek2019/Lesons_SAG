// © 2000 Dmytro Borovsky.

var rows = testTable.children[0].rows;
var max = 0;
var min = 0;

function count() {
	for (var i = 1; i < rows.length; i++)
		if ((rows[i].cells[0].tagName == 'TD') && (rows[i].cells[1])) {
			max += rows[i].cells[0].children[0].score * 1;
				if (rows[i].cells[0].children[0].checked == (testTable.children[0].rows[i].cells[0].children[0].correct == 'да'))
					min += rows[i].cells[0].children[0].score * 1;
		}
	max -= min;
}

var	sum = -min;
function check() {
	sum = -min;
	var answers = 0;
	for (var i = 0; i < testTable.children[0].rows.length; i++)
		if (rows[i].cells[0].tagName == 'TD')
			if (rows[i].cells[0].children[0].checked == (rows[i].cells[0].children[0].correct == 'да'))
				sum += rows[i].cells[0].children[0].score * 1;
	result.innerText = 'Отвечая на вопросы теста, Вы набрали ' + Math.round(100 * sum / max) + ' балл' + getMasculineCaseExtention(Math.round(100 * sum / max)) + ' из 100-та.';
	if (Math.round(100 * sum / max) < 60)
		result.innerHTML += ' Для разблокирования следующего урока Вам необходимо набрать <b>не менее<\/b> 60<sup style="text-decoration: underline;">ти<\/sup> баллов. Проработайте ещё раз материал этого урока и снова ответьте на вопросы теста. Также, можете <a href="..\/common\/test-tips.xml" title="Советы по тестам.">почитать советы по сдаче тестов<\/a>.';
	scrollTo(0, result.offsetTop);
	saveResults();
	lockUnlock();
}

function getMasculineCaseExtention(n) {
	n = Math.abs(n);
	if ((n >= 5) && (n <= 20))
		return 'ов';
	if ((n % 10) == 1)
		return '';
	if ((n % 10) == 0)
		return 'ов';
	if ((n % 10) <= 4)
		return 'а';
	return 'ов';
}
function saveResults() {
var path;
	if (document.location.href.toLowerCase().indexOf('design') != -1)
		path = 'Design';
	if (document.location.href.toLowerCase().indexOf('hardware') != -1)
		path = 'Hardware';
	if (document.location.href.toLowerCase().indexOf('program') != -1)
		path = 'Programming';
var HTML = document.documentElement.outerHTML;
	HTML = HTML.replace('<SCRIPT', '<NOSCRIPT');
	HTML = HTML.replace('</SCRIPT', '</NOSCRIPT');
	HTML = HTML.replace('<BUTTON', '<NOSCRIPT');
	HTML = HTML.replace('</BUTTON', '</NOSCRIPT');
	HTML = HTML.replace(' onload=count();', '');
var FS = new ActiveXObject('Scripting.FileSystemObject');
var fileName = prompt('Введите путь и имя файла для сохранения результатов теста. По умолчанию сохранение осуществляется на диск A:.', 'A:\\' + path + ' Test Log.html');
	if (fileName) {
	var testResult = FS.CreateTextFile(fileName, true, true);
		testResult.Write(HTML);
		testResult.Close();
	}
}
function lockUnlock() {
var section, result, XML;
	if (document.location.href.toLowerCase().indexOf('design') != -1)
		section = 'дизайн';
	if (document.location.href.toLowerCase().indexOf('hardware') != -1)
		section = 'залізо';
	if (document.location.href.toLowerCase().indexOf('program') != -1)
		section = 'програми';

	if (Math.round(100 * sum / max) < 60)
		result = 'ні'
	else
		result = 'так';

	userDataControl.load('Шаг')
var	isValidXML = userDataControl.getAttribute('Уроки');
	if ((isValidXML == '') || (isValidXML == null)) {
		XML = userData.XMLDocument;
		userData.src = '../common/maindata.src';
	} else {
		XML = new ActiveXObject('Microsoft.XMLDOM');
		XML.loadXML(isValidXML);
	}

	if (XML.childNodes.item(0).childNodes.length < 10) {
		var newNode = XML.createElement('заняття')
		with(newNode) {
			setAttribute('номер', '09');
			setAttribute('дизайн', 'ні');
			setAttribute('залізо', 'ні');
			setAttribute('програми', 'ні');
			setAttribute(section, result);
		}
		XML.childNodes.item(0).appendChild(newNode);
	} else
		XML.childNodes.item(0).childNodes.item(09).setAttribute(section, result);

	userDataControl.removeAttribute('урок09');
	userDataControl.setAttribute('урок09', XML.xml);
	userDataControl.save('Шаг');

}

alert('script');