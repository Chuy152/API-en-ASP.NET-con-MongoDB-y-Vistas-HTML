<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoFinalU1._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <style>

        /* Contenidoo central de la pagina principal*/
        .Division{
            flex: 1%;
            margin: 30px 50px;
        }

        .ImagenAcomodar{
            display: flex;
        }

        .ImagenAcomodar img{
            transition: transform 0.5s;
            padding: 40px;
           
        }

        .ImagenAcomodar img:hover{
            transform: scale(1.03);
        }

    </style>


    <!-- Contenido central de la pagina principal -->
    <div class="Division">
        <h1>BIENVENIDA</h1>
        <br />
        <h3>Creador</h3>
        <P><i>Comprometido a ofrecer la mejor calidad de paginas web. Ofreciendo seguridad, rendimiento y fiabilidad a sus clientes publico</i></P> 
        <div class="ImagenAcomodar">
            <img src="/scr/yo.png" height="" width="">
            <img src="/scr/yo2.png" height="" width="">
            <img src="/scr/yo3.png" height="" width="">
        </div>

        <br />

        <h3>Tus sueños son tu realidad</h3>
        <p><i>Todo comenzó con una idea y con esfuerzo terminó siendo una realidad</i></p>
      
    </div>  

</asp:Content>
