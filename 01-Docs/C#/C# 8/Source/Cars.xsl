<?xml version="1.0"?>
<xsl:stylesheet version="1.0"  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
    <body>
      <h1>MyCars</h1>
        <hr />
        <table width="100%" border="1">
          <tr bgcolor="gold">            
            <td>
              <b>Manufactured</b>
            </td>
            <td>
              <b>Model</b>
            </td>
            <td>
              <b>Year</b>
            </td>
            <td>
              <b>Color</b>
            </td>
            <td>
              <b>Speed</b>
            </td>
          </tr>
           <xsl:for-each select="Cars/Car">
            <tr>
              <td><xsl:value-of select="Manufactured" /></td>
              <td><xsl:value-of select="Model" /></td>
              <td><xsl:value-of select="Year" /></td>
              <td><xsl:value-of select="Color" /></td>
              <td><xsl:value-of select="Speed" /></td>
            </tr>
           </xsl:for-each>
         </table>
    </body>
  </html>
</xsl:template>
</xsl:stylesheet> 
