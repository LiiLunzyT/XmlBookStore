<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
	<xsl:param name="CustomerID"></xsl:param>
    <xsl:template match="/">
		<xsl:variable name="_Customer" select="//Customer[@CustomerID = $CustomerID]" />
		<table border="1">
			<tr>
				<td>Mã Sách</td>
				<td>Tên Sách</td>
				<td>Số lượng</td>
				<td>Đơn giá</td>
				<td>Tổng</td>
			</tr>
			<xsl:for-each select="$_Customer/Cart/CartItem">
				<tr>
					<xsl:variable name="_Book" select="//Book[@BookID = current()/BookID]" />
					<td>
						<xsl:value-of select="$_Book/@BookID"/>
					</td>
					<td>
						<xsl:value-of select="$_Book/BookName"/>
					</td>
					<td>
						<xsl:value-of select="Quantity"/>
					</td>
					<td>
						<xsl:value-of select="$_Book/BookPrice"/>
					</td>
					<td>
						<xsl:value-of select="$_Book/BookPrice * Quantity"/>
					</td>
					
				</tr>
			</xsl:for-each>
		</table>
    </xsl:template>
</xsl:stylesheet>
