<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="list">
    <table class="table" cellpadding="4" cellspacing="0" style="border-collapse:collapse;" border="1" width="100%">
      <tr>
        <th>ID</th>
        <th>XCode</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
      <xsl:apply-templates select="item"></xsl:apply-templates>      
    </table>
  </xsl:template>

  <xsl:template match="item">
    <tr>
      <td>
        <a>
          <xsl:attribute name="href">
            <xsl:value-of select="link"/>
          </xsl:attribute>
          #<xsl:value-of select="ID"/>
        </a>
      </td>
      <td><xsl:value-of select="XCode"/></td>
      <td><xsl:value-of select="ProjectName"/></td>
      <td><xsl:value-of select="Description"/></td>
    </tr>
  </xsl:template>
</xsl:stylesheet>
