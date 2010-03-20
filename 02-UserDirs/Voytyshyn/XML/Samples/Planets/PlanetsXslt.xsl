<?xml version="1.0" ?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
		<head>
			<title>Planets</title>
		</head>
			<body>
				<table border="1">
					<tr>
						<th>name</th>
						<th>mass</th>
						<th>day</th>
						<th>radius</th>
						<th>density</th>
						<th>distance</th>
					</tr>
					<xsl:apply-templates />
				</table>

			</body>
		</html>
	</xsl:template>	
	<xsl:template match="planet">		
		<tr>
			<td>
				<xsl:value-of select="name" /> 
			</td>	
			<td>
				<xsl:apply-templates select="mass" /> 				
			</td>
			<td>
				<xsl:apply-templates select="day" />
			</td>
			<td>
				<xsl:apply-templates select="radius" />
			</td>
			<td>
				<xsl:apply-templates select="density" />
			</td>
			<td>
				<xsl:apply-templates select="distance" />
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="mass">
		<xsl:value-of select="." />
		<xsl:text> </xsl:text>
		<xsl:value-of select="@units" />
	</xsl:template>
	<xsl:template match="day">
		<xsl:value-of select="." />
		<xsl:text> </xsl:text>
		<xsl:value-of select="@units" />
	</xsl:template>
	<xsl:template match="radius">
		<xsl:value-of select="." />
		<xsl:text> </xsl:text>
		<xsl:value-of select="@units" />
	</xsl:template>
	<xsl:template match="density">
		<xsl:value-of select="." />
		<xsl:text> </xsl:text>
		<xsl:value-of select="@units" />
	</xsl:template>
	<xsl:template match="distance">
		<xsl:value-of select="." />
		<xsl:text> </xsl:text>
		<xsl:value-of select="@units" />
	</xsl:template>
	<xsl:template match="distance">
		<xsl:value-of select="." />
		<xsl:text> </xsl:text>
		<xsl:value-of select="@units" />
	</xsl:template>

</xsl:stylesheet>