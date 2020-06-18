<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
      <xsl:variable name="_listBook" select="//Books" />
      <h2 style="text-align: center;">Danh sách Sản phẩm</h2>
      <div class="listBook">
        <xsl:for-each select="$_listBook/Book">
          <div class="card-book">
            <div class="card-body">
              <div class="card-img">
                <img>
					<xsl:attribute name="src">../Images/<xsl:value-of select="@BookID"/>.png</xsl:attribute>
					<xsl:attribute name="onerror">this.onerror=null;this.src='../Images/alt_img.png'</xsl:attribute>
				</img>
              </div>
              <div class="card-name">
                <xsl:value-of select="BookName"/>
              </div>
              <div class="card-author">
                <xsl:variable name="_AuthorID" select="BookAuthor/@AuthorID" />
                <xsl:value-of select="/Authors/Author[@AuthorID=$_AuthorID]/AuthorName"/>
              </div>
              <div class="card-price">
                <xsl:variable name="_price" select="BookPrice" />
                <xsl:variable name="_discount" select="BookDiscount" />
                <div class="first-price">
                  <xsl:value-of select="($_price div 100) * (100 - $_discount)"/> VNĐ
                </div>
                <div class="second-price">
                  <xsl:value-of select="$_price"/> VNĐ
                </div>
              </div>
            </div>
            <div class="card-control">
              <button class="card-add" type="button" onclick="addToCart('{@BookID}')">
                Thêm vào giỏ hàng
              </button>
            </div>
          </div>
        </xsl:for-each>
      </div>
    </xsl:template>
</xsl:stylesheet>
