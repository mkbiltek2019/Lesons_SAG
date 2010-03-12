<?xml version="1.0" encoding="windows-1251" ?>

<xsl:stylesheet xmlns:xsl="http://www.w3.org/TR/WD-xsl">

<xsl:template match="* | @* | comment() | pi() | text()"><xsl:copy><xsl:apply-templates select="* | @* | comment() | pi() | text()" /></xsl:copy></xsl:template>

<xsl:template match="@подсказка">
		<xsl:attribute name="title"><xsl:value-of select="." /></xsl:attribute>
</xsl:template>

<xsl:template match="@класс">
		<xsl:attribute name="class"><xsl:value-of select="." /></xsl:attribute>
</xsl:template>

<xsl:template match="рисунок/@подсказка">
		<xsl:attribute name="alt"><xsl:value-of select="." /></xsl:attribute>
</xsl:template>

<xsl:template match="абзац">
	<p>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</p>
</xsl:template>

<xsl:template match="u">
	<b>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</b>
</xsl:template>

<xsl:template match="a[@target = 'rtop']">
	<xsl:value-of select="." />
</xsl:template>

<xsl:template match="pre/p">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
</xsl:template>

<xsl:template match="font/@face">
	<xsl:attribute name="face">monotype.com, lucida console, monospace</xsl:attribute>
</xsl:template>

<xsl:template match="pre/font/@face | pre/*/font/@face | pre/font/@size | pre/*/font/@size" />

<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
<!--                       НАЧАЛО МОЕГО  БЛОКА                       -->
<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->

<xsl:template match="предмет">
	<h1 align="center">
	<u>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</u>
	</h1>
</xsl:template>

<xsl:template match="тема">
	<h2 align="center" style="color:maroon">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h2>
</xsl:template>

<xsl:template match="примечание">
	<hr />
	<p>
	<b>Примечание: </b>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</p>
	<hr />
</xsl:template>

<xsl:template match="исходники">
	<p>
Исходный код приложения расположен в папке:
	<a>	
		<xsl:attribute name="href"><xsl:value-of select="." /></xsl:attribute>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</a>.
	</p>
</xsl:template>

<xsl:template match="комментарий">
	<!--
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	-->
</xsl:template>

<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
<!--                       КОНЕЦ МОЕГО  БЛОКА                       -->
<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->

<xsl:template match="заголовок[@уровень='1'] | заголовок">
	<h1>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h1>
</xsl:template>

<xsl:template match="заголовок[@уровень='2']">
	<h2>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h2>
</xsl:template>

<xsl:template match="заголовок[@уровень='3']">
	<h3>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h3>
</xsl:template>

<xsl:template match="заголовок[@уровень='4']">
	<h4>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h4>
</xsl:template>

<xsl:template match="заголовок[@уровень='5']">
	<h5>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h5>
</xsl:template>

<xsl:template match="заголовок[@уровень='6']">
	<h6>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</h6>
</xsl:template>

<xsl:template match="рисунок">
	<img>
		<xsl:attribute name="src"><xsl:value-of select="@файл" /></xsl:attribute>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</img>
</xsl:template>

<xsl:template match="список/абзац">
	<li>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</li>
</xsl:template>

<xsl:template match="список | список[@тип='маркер']">
	<ul>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</ul>
</xsl:template>

<xsl:template match="список[@тип='1']">
	<ol>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</ol>
</xsl:template>

<xsl:template match="список[@тип='I'] | список[@тип='І']">
	<ol type="I">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</ol>
</xsl:template>

<xsl:template match="список[@тип='A'] | список[@тип='А']">
	<ol type="A">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</ol>
</xsl:template>

<xsl:template match="список[@тип='a'] | список[@тип='а']">
	<ol type="a">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</ol>
</xsl:template>

<xsl:template match="код">
	<pre>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</pre>
</xsl:template>

<xsl:template match="стиль | выбор"><span><xsl:apply-templates select="* | @* | comment() | pi() | text()" /></span></xsl:template>

<xsl:template match="ссылка/@файл">
		<xsl:attribute name="href"><xsl:value-of select="." /></xsl:attribute>
</xsl:template>

<xsl:template match="ссылка">
	<a>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</a>
</xsl:template>

<xsl:template match="стиль">
	<span>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</span>
</xsl:template>

<xsl:template match="ж | пж | полужирный">
	<span style="font-weight: bolder;">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</span>
</xsl:template>

<xsl:template match="к | курсив">
	<i>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</i>
</xsl:template>

<xsl:template match="жк | кж | пжк | ж-к | к-ж | пж-к | к-пж | полужирный-курсив | полужирныйкурсив">
	<span style="font-weight: bolder; font-style: italic;">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</span>
</xsl:template>

<xsl:template match="строка | ячейка" />

<xsl:template match="таблица">
	<table class="common">
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</table>
</xsl:template>

<xsl:template match="таблица/строка">
	<tr>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</tr>
</xsl:template>

<xsl:template match="таблица/строка/ячейка">
	<td>
		<xsl:attribute name="rowSpan"><xsl:value-of select="@строки" /></xsl:attribute>
		<xsl:attribute name="colSpan"><xsl:value-of select="@столбцы" /></xsl:attribute>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</td>
</xsl:template>

<xsl:template match="черта | линия | разделитель">
	<hr>
		<xsl:apply-templates select="* | @* | comment() | pi() | text()" />
	</hr>
</xsl:template>


<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
<!--                       ОСНОВНОЙ БЛОК                       -->
<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
<!--                          У Р О К                          -->

<xsl:template match="/Урок">
	<HTML>
		<head>

			<script language="JavaScript">
				if (top == window) {
					alert('Все страницы должны открываться только из оболочки «Шаг».\nВы не можете просмотреть эту страницу вне оболочки.');
					location.replace('about:blank');
				}
			</script>

			<title><xsl:value-of select="@название" /></title>
			<link rel="stylesheet" type="text/css" href="../common/style.css" />
		</head>
		<body id="body">
			<table class="headerFooter">
				<tr>
					<td>
						<a accesskey="р" title="Возврат к предыдущему уроку">
							<xsl:if test="@предыдущий">
								<xsl:attribute name="href"><xsl:value-of select="@предыдущий" /></xsl:attribute>
							</xsl:if>
							П<u>р</u>едыдущая тема
						</a>
					</td>
					<td>
						<a accesskey="о" href="index.xml" title="Список всех тем раздела">
							<u>О</u>главление
						</a>
					</td>
					<td>
						<a accesskey="с" title="Переход к следующему уроку">
							<xsl:if test="@следующий">
								<xsl:attribute name="href"><xsl:value-of select="@следующий" /></xsl:attribute>
							</xsl:if>
							<u>С</u>ледующая тема
						</a>
					</td>
				</tr>
			</table>
			<hr />

			<xsl:apply-templates select="/Урок/*" />

			<hr />
			<table class="headerFooter">
				<tr>
					<td>
						<a accesskey="н" href="javascript:history.back()" title="Возврат к только что просмотренной странице">
							<u>Н</u>азад
						</a>
					</td>
					<td>
						<a accesskey="п" href="javascript:print()" title="Распечатка этой темы на принтере">
							<u>П</u>ечать
						</a>
					</td>
					<td>
						<a accesskey="с" title="Переход к следующему уроку">
							<xsl:if test="@следующий">
								<xsl:attribute name="href"><xsl:value-of select="@следующий" /></xsl:attribute>
							</xsl:if>
							<u>С</u>ледующая тема
						</a>
					</td>
				</tr>
			</table>
			<hr />
			
			<xsl:if test="/Урок[@copyright]">
				<div style="font-size: 60%;">
					<p>
						<xsl:value-of select="./@copyright" />
						Этот материал защищён Законом Украины «Про авторське право и суміжні права» и международными соглашениями об авторском праве и смежных правах авторов и расценивается как литературное произведение.
						Любое копирование или иное распространение этого материала невозможно до 2053.
					</p>
				</div>
			</xsl:if>
		</body>
	</HTML>
</xsl:template>

<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->

<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->

<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->

<xsl:template match="вопрос">
	<tr>
		<th colSpan="2">
			<xsl:value-of select="@текст" />
		</th>
	</tr>
	<xsl:apply-templates select="код" />
	<xsl:apply-templates select="вариант" order-by="@текст" />
</xsl:template>

<xsl:template match="вопрос[@файл]">
	<tr>
		<th colSpan="2">
			<a>
				<xsl:attribute name="href"><xsl:value-of select="@файл" /></xsl:attribute>
				<xsl:apply-templates select="@подсказка" />
				<xsl:value-of select="@текст" />
			</a>
		</th>
	</tr>
	<xsl:apply-templates select="код" />
	<xsl:apply-templates select="вариант" order-by="@текст" />
</xsl:template>

<xsl:template match="вопрос/вариант">
	<tr>
		<td class="CB">
			<input type="checkbox" value="false">
				<xsl:attribute name="correct"><xsl:value-of select="@верен" /></xsl:attribute>
				<xsl:attribute name="score"><xsl:value-of select="@оценка" /></xsl:attribute>
			</input>
		</td>
		<td>
			<xsl:value-of select="@текст" />
			<xsl:if test="код">
							<pre style="margin: 0;"><xsl:value-of select="код" /></pre>
			</xsl:if>
		</td>
	</tr>
</xsl:template>

<xsl:template match="вопрос/вариант[@файл]">
	<tr>
		<td class="CB">
			<input type="checkbox" value="false">
				<xsl:attribute name="correct"><xsl:value-of select="@верен" /></xsl:attribute>
				<xsl:attribute name="score"><xsl:value-of select="@оценка" /></xsl:attribute>
			</input>
		</td>
		<td>
			<a>
				<xsl:attribute name="href"><xsl:value-of select="@файл" /></xsl:attribute>
				<xsl:apply-templates select="@подсказка" />
				<xsl:value-of select="@текст" />
			</a>
		</td>
	</tr>
</xsl:template>

<xsl:template match="вопрос/код">
	<tr>
		<td colSpan="2">
			<pre style="margin: 0;"><xsl:apply-templates select="* | @* | comment() | pi() | text()" /></pre>
		</td>
	</tr>
</xsl:template>




<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
<!--                       ОСНОВНОЙ БЛОК                       -->
<!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
<!--                          Т Е С Т                          -->

<xsl:template match="/Тест">
	<HTML>
		<head>
			<title><xsl:value-of select="@название" /></title>
			<link rel="stylesheet" type="text/css" href="../common/style.css" />
		</head>
		<body id="body" oncontextmenu="return false;">
			<span id="userDataControl" style="behavior: url('#default#userData'); display: none"></span>
			<XML id="userData" onreadystatechange="if ((this.readyState == 'complete') || (this.readyState == 4)) { }"></XML>
			<table class="headerFooter">
				<tr>
					<td>
						<a accesskey="р" title="Возврат к предыдущему уроку">
							<xsl:if test="@предыдущий">
								<xsl:attribute name="href"><xsl:value-of select="@предыдущий" /></xsl:attribute>
							</xsl:if>
							П<u>р</u>едыдущая тема
						</a>
					</td>
					<td>
						<a accesskey="о" href="index.xml" title="Список всех тем раздела">
							<u>О</u>главление
						</a>
					</td>
					<td>
						<a accesskey="с" title="Переход к следующему уроку">
							<xsl:if test="@следующий">
								<xsl:attribute name="href"><xsl:value-of select="@следующий" /></xsl:attribute>
							</xsl:if>
							<u>С</u>ледующая тема
						</a>
					</td>
				</tr>
			</table>
			<hr />
			<h1>
				<xsl:value-of select="@название" />
			</h1>
			<p>Отметьте верные варианты галочками, после чего нажмите на кнопку «<u>Р</u>езультаты» внизу.</p>
			<p>Перед прохождением теста <a href="../common/test-tips.xml" title="Советы по тестам.">почитайте советы</a>.</p>
			<hr style="color: windowText; height: 2px;" />

			<table id="testTable">
				<tBody>
					<xsl:apply-templates select="вопрос" order-by="@текст" />
				</tBody>
			</table>

			<hr style="color: windowText; height: 2px;" />
			
			<button accessKey="р" id="checkButton" style="font-size: 100%; height: 1.85em; width: 8.5em;"><u>Р</u>езультаты</button>
			
			<p id="result">Для проверки правильности ответов и оценки Ваших знаний нажмите на кнопку «<u>Р</u>езультаты» строкой выше.</p>

			<hr />
			<table class="headerFooter">
				<tr>
					<td>
						<a accesskey="н" href="javascript:history.back()" title="Возврат к только что просмотренной странице">
							<u>Н</u>азад
						</a>
					</td>
					<td>
						<a accesskey="п" href="javascript:print()" title="Распечатка этого теста на принтере">
							<u>П</u>ечать
						</a>
					</td>
					<td>
						<a accesskey="с" title="Переход к следующему уроку">
							<xsl:if test="@следующий">
								<xsl:attribute name="href"><xsl:value-of select="@следующий" /></xsl:attribute>
							</xsl:if>
							<u>С</u>ледующая тема
						</a>
					</td>
				</tr>
			</table>

			<script language="JavaScript" type="text/javascript" for="checkButton" event="onclick">
				if (top != window)
					top.check(testTable, result, event.shiftKey)
					if (!event.shiftKey)
						checkButton.disabled = true;
			</script>
			<script language="JavaScript" type="text/javascript" for="body" event="onload">
				if (top != window)
					top.count(testTable)
				else {
					checkButton.disabled = true;
					alert('Все страницы должны открываться только из оболочки «Шаг».\nВы не можете отвечать на вопросы теста вне оболочки, поэтому кнопка «Результаты» отключена. Для её включения вернитесь в оболочку и откройте тест оттуда.');
				}
			</script>

		</body>
	</HTML>
</xsl:template>

<xsl:template match="/">
	<xsl:apply-templates select="*" />
</xsl:template>


</xsl:stylesheet>
