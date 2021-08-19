<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="CustomErrors.ErrorPages.Oops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>

<title>Error</title>

<link href="https://fonts.googleapis.com/css?family=Montserrat:200,400,700" rel="stylesheet"/>

<link type="text/css" rel="stylesheet" href="../css/style.css" />

</head>
<body>
<div id="notfound">
<div class="notfound">
<div class="notfound-404">
<h1>Oops!</h1>
<h2><asp:Label ID="statusanddescription" runat="server" Text=""></asp:Label></h2>
</div>
<a href="/">Volver al inicio</a>
</div>
</div>
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13" type="9ac50e0e91726083557e0fb8-text/javascript"></script>
<script type="9ac50e0e91726083557e0fb8-text/javascript">
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-23581568-13');
</script>
<script src="https://ajax.cloudflare.com/cdn-cgi/scripts/95c75768/cloudflare-static/rocket-loader.min.js" data-cf-settings="9ac50e0e91726083557e0fb8-|49" defer=""></script></body>
</html>