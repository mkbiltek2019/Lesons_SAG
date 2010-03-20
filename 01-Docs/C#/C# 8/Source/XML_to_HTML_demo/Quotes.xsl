<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
    <body>
      <h1 style="background-color: teal; color: white;
      font-size: 24pt; text-align: center; letter-spacing: 1.0em">
       Лучшие цитаты
      </h1>
      <table border="1">
        <tr style="font-size: 12pt; font-family: verdana; font-weight: bold">
          <td style="text-align: center">Цитата</td>
          <td style="text-align: center">Автор</td>
        </tr>
        <xsl:for-each select="Quotes/Quote">
          <xsl:sort select="Author" />
            <tr styls="font-size: 10pt; font-faraily: verdana">
               <td><xsl:value-of select="Text" /></td>
               <td><i><xsl:value-of select="Author" /></i></td>
            </tr>
        </xsl:for-each>
      </table>
    </body>
    </html>
</xsl:template>
</xsl:stylesheet> 
