<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
	<xsl:param name="CustomerID"></xsl:param>
    <xsl:template match="/">
		<xsl:variable name="_Customer" select="//Customer[CustomerID = CustomerID]" />
		<table border="1">
			<tr>
				<th>Mã Sách</th>
				<th>Tên Sách</th>
				<th>Số lượng</th>
				<th>Đơn giá</th>
				<th>Tổng</th>
			</tr>
			<xsl:for-each select="$_Customer/Cart/CartItem">
				<tr>
					<xsl:variable name="_Book" select="//Book[BookID = current()/BookID]" />
					<td>
						<xsl:value-of select="$_Book/BookID"/>
					</td>
					<td>
						<xsl:value-of select="$_Book/BookName"/>
					</td>
					<td style="text-align: center;">
						<button class="btn" onclick="btnDecreaseOnClick('{$_Book/BookID}')">-</button>
						<xsl:value-of select="Quantity"/>
						<button class="btn" onclick="btnIncreaseOnClick('{$_Book/BookID}')">+</button>
					</td>
					<td style="text-align: right">
						<xsl:value-of select="format-number($_Book/BookPrice, '###,###,###')"/>
					</td>
					<td style="text-align: right">
            <xsl:variable name="_price" select="($_Book/BookPrice div 100) * (100 - $_Book/BookDiscount)"/>
						<xsl:value-of select="format-number($_price * Quantity, '###,###,###')"/>
						VNĐ
					</td>
				</tr>
			</xsl:for-each>
		</table>
    </xsl:template>
</xsl:stylesheet>
