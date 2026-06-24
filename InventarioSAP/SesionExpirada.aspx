<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SesionExpirada.aspx.vb" Inherits="InventarioSAP.SesionExpirada" %>

<!DOCTYPE html>
<html lang="es">

<head>

<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<title>Suite AR - Sesión Expirada</title>

<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">

<style>

*{
    margin:0;
    padding:0;
    box-sizing:border-box;
}

/* =========================
   HTML / BODY
========================= */

html{

    height:100%;

    overflow-x:hidden;
    overflow-y:auto;
}

body{

    min-height:100vh;

    overflow:hidden;

    font-family:'Segoe UI',sans-serif;

    background:
    linear-gradient(
    135deg,
    rgba(35,0,28,0.82),
    rgba(95,0,70,0.72)
    ),

    url('https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?q=80&w=2070&auto=format&fit=crop')
    center center/cover no-repeat;

    display:flex;
    align-items:center;
    justify-content:center;

    position:relative;
}

/* =========================
   OVERLAY
========================= */

body::before{

    content:'';

    position:absolute;

    inset:0;

    background:
    radial-gradient(circle at top left,
    rgba(255,255,255,0.10),
    transparent 35%),

    radial-gradient(circle at bottom right,
    rgba(255,255,255,0.08),
    transparent 30%);

    pointer-events:none;
}

/* =========================
   GLOW
========================= */

.glow{

    position:absolute;

    border-radius:50%;

    filter:blur(80px);

    animation:float 10s ease-in-out infinite;

    pointer-events:none;
}

.glow1{

    width:500px;
    height:500px;

    background:rgba(255,255,255,0.05);

    top:-180px;
    left:-180px;
}

.glow2{

    width:350px;
    height:350px;

    background:rgba(255,255,255,0.05);

    bottom:-120px;
    right:-120px;

    animation-delay:2s;
}

@keyframes float{

    0%{
        transform:translateY(0px);
    }

    50%{
        transform:translateY(20px);
    }

    100%{
        transform:translateY(0px);
    }
}

/* =========================
   CARD
========================= */

.session-card{

    width:520px;

    max-width:92%;

    padding:40px;

    text-align:center;

    background:rgba(255,255,255,0.08);

    backdrop-filter:blur(24px);

    -webkit-backdrop-filter:blur(24px);

    border:1px solid rgba(255,255,255,0.10);

    border-radius:34px;

    box-shadow:
    0 30px 80px rgba(0,0,0,0.45);

    position:relative;

    z-index:5;
}

/* =========================
   ICON
========================= */

.icon-wrapper{

    width:72px;
    height:72px;

    margin:0 auto 18px auto;

    border-radius:20px;

    background:rgba(255,255,255,0.12);

    display:flex;
    align-items:center;
    justify-content:center;

    backdrop-filter:blur(10px);

    box-shadow:
    0 10px 24px rgba(0,0,0,0.18);
}

.icon-wrapper i{

    font-size:30px;

    color:white;
}

/* =========================
   BRAND
========================= */

.suite-name{

    font-size:36px;

    font-weight:700;

    color:white;

    letter-spacing:1px;

    margin-bottom:6px;
}

/* =========================
   STATUS
========================= */

.status{

    display:inline-flex;

    align-items:center;

    gap:8px;

    padding:8px 14px;

    border-radius:999px;

    background:rgba(255,255,255,0.08);

    border:1px solid rgba(255,255,255,0.08);

    color:white;

    font-size:11px;

    margin-bottom:20px;
}

.status-dot{

    width:8px;
    height:8px;

    border-radius:50%;

    background:#FFB347;
}

/* =========================
   TITLE
========================= */

.title{

    font-size:26px;

    font-weight:700;

    color:white;

    margin-bottom:12px;
}

/* =========================
   MESSAGE
========================= */

.message{

    font-size:14px;

    line-height:1.9;

    color:rgba(255,255,255,0.82);

    max-width:360px;

    margin:auto;
}

/* =========================
   BUTTON
========================= */

.btn-login{

    width:100%;

    max-width:280px;

    height:50px;

    margin-top:28px;

    border:none;

    border-radius:16px;

    background:
    linear-gradient(
    135deg,
    #E11784,
    #BC70C7
    );

    color:white;

    font-size:13px;

    font-weight:600;

    text-decoration:none;

    display:inline-flex;

    align-items:center;

    justify-content:center;

    gap:10px;

    transition:.30s;
}

.btn-login:hover{

    transform:translateY(-2px);

    box-shadow:
    0 12px 28px rgba(0,0,0,0.30);
}

/* =========================
   FOOTER
========================= */

.footer{

    margin-top:22px;

    text-align:center;

    font-size:10px;

    line-height:1.8;

    color:rgba(255,255,255,0.42);
}

/* =========================
   RESPONSIVE
========================= */

@media(max-width:768px){

    .session-card{

        padding:32px 22px;
    }

    .suite-name{

        font-size:30px;
    }

    .title{

        font-size:22px;
    }
}

/* =========================
   LOW HEIGHT
========================= */

@media(max-height:700px){

    html{

        overflow-y:auto;
    }

    body{

        align-items:flex-start;

        min-height:auto;

        padding:20px 0;
    }

    .session-card{

        margin:20px auto;
    }
}

</style>

</head>

<body>

<div class="glow glow1"></div>
<div class="glow glow2"></div>

<div class="session-card">

    <div class="icon-wrapper">

        <i class="bi bi-shield-exclamation"></i>

    </div>

    <div class="suite-name">

        Suite AR

    </div>

    <div class="status">

        <div class="status-dot"></div>

        SESIÓN EXPIRADA

    </div>

    <div class="title">

        Sesión expirada

    </div>

    <div class="message">

        Tu sesión ya no se encuentra activa.
        Para continuar, vuelve a iniciar sesión en Suite AR.

    </div>

    <%--<a href="Login.aspx" class="btn-login">

        <i class="bi bi-box-arrow-in-right"></i>

        Volver a iniciar sesión

    </a>--%>

    <div class="footer">

        © 2026 Suite AR<br>
        Desarrollo e Innovación · Acurio Restaurantes

    </div>

</div>

</body>

</html>
