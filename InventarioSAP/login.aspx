<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="InventarioSAP.login" %>

<!DOCTYPE html>

<html lang="en">
	<!--begin::Head-->
	<head>
		<%--<base href="../">--%>
		<title>ARInventario</title>
		<meta charset="utf-8" />
		<meta name="description" content="Área de Solución de Negocios - Sistema Web de Administrador de Evaluaciones de Desempeño en Acurio Restaurantes." />
		<meta name="keywords" content="Start, bootstrap, bootstrap 5, admin themes, free admin themes, bootstrap admin, bootstrap dashboard, html admin theme, html template" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<meta property="og:locale" content="en_US" />
		<meta property="og:type" content="article" />
		<meta property="og:title" content="ARInventario" />
		<meta property="og:url" content="https://themes.getbootstrap.com/product/start-multipurpose-admin-dashboard-theme/" />
		<meta property="og:site_name" content="Keenthemes | Start" />
		<link rel="canonical" href="https://preview.keenthemes.com/start" />
		<link rel="shortcut icon" href="images/images_sistema/icono2.ico" />
		<!--begin::Fonts-->
		<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" />
		<!--end::Fonts-->
		<!--begin::Global Stylesheets Bundle(used by all pages)-->
		<link href="theme/dist/assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
		<link href="theme/dist/assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
		<!--end::Global Stylesheets Bundle-->
		<script src="https://www.google.com/recaptcha/api.js" async defer></script>
	</head>
	<!--end::Head-->
	<!--begin::Body-->
	<body id="kt_body" class="bg-white">
		<!--begin::Main-->
			<div class="d-flex flex-column flex-root">
			<!--begin::Login-->
			<div class="d-flex flex-column flex-lg-row flex-column-fluid" id="kt_login">
				<!--begin::Aside-->
				<%--<div class="d-flex flex-column flex-lg-row-auto bg-primary w-lg-600px pt-15 pt-lg-0">--%>
				<div class="d-flex flex-column flex-lg-row-auto w-lg-600px pt-15 pt-lg-0" style="background-image: url(images/BGlateral.png); background-size: cover; background-position: center;">
					<!--begin::Aside Top-->
					<div class="d-flex flex-row-fluid flex-center flex-column-auto flex-column text-center mb-5">
						<!--begin::Aside Logo-->
						<a href="../dist/index.html" class="mb-6">
						</a>
						<!--end::Aside Logo-->
						<!--begin::Aside Subtitle-->


						<br />
						<br />
						<br />
					    <br />
						<br />
						<br />
						<br />

						<br />
						<br />

						<img alt="Logo" src="images/LogoARInventa.png" class="h-10px h-lg-100px" />


						<br />
						<br />
					    <br />
						<br />
						<br />
						<br />
					    <br />
						<br />
						<br />
						<br />
						<br />
						<br />
					    <br />
						<br />



						<img alt="Logo" src="images/LogoAR_blanco.png" class="h-500px h-lg-40px" />

						<!--end::Aside Subtitle-->
					</div>
					<!--end::Aside Top-->
					<!--begin::Illustration-->



					<!--end::Illustration-->
				</div>
				<!--begin::Aside-->
				<!--begin::Content-->
				
				<div class="login-content flex-lg-row-fluid d-flex flex-column justify-content-center position-relative overflow-hidden py-10 py-lg-20 px-10 p-lg-7 mx-auto mw-450px w-100">
					<!--begin::Wrapper-->
					<div class="d-flex flex-column-fluid flex-center py-10">
						<!--begin::Signin Form-->
						<form class="form w-100"  id="form_login" runat="server">
							<br />
							<br />
							<br />

							<!--begin::Title-->
							<div class="pb-5 pb-lg-15">
								<h3 class="fw-bolder display-6" style="color: #860264">Inicia sesión</h3>
								<div class="text-muted fw-bold fs-3">
								<a href="#" class="text-primary fw-bolder" id="kt_login_signin_form_singup_button"></a></div>
							</div>
							<!--begin::Title-->
							<!--begin::Form group-->
							<div class="fv-row mb-10">
								<label class="form-label fs-6 fw-bolder text-dark">Usuario</label>
								<%--<input class="form-control form-control-lg form-control-solid" type="text" name="username" autocomplete="off" />--%>
								<asp:TextBox ID="txtusuario" runat="server" name="username"  class="form-control form-control-lg form-control-solid" TabIndex="1"></asp:TextBox>

							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="fv-row mb-10">
								<div class="d-flex justify-content-between mt-n5">
									<label class="form-label fs-6 fw-bolder text-dark pt-5">Contraseña</label>
									<a href="#" class="text-primary fs-6 fw-bolder text-hover-primary pt-5" id="kt_login_signin_form_password_reset_button"></a>
						
								</div>
								<asp:TextBox ID="txtcontraseña" runat="server" name="password"  class="form-control form-control-lg form-control-solid" TextMode="Password" TabIndex="2"></asp:TextBox>
								<%--<input class="form-control form-control-lg form-control-solid" type="password" name="password" autocomplete="off" />--%>
							</div>
							<div class="pb-lg-0 pb-5">
								<div class="g-recaptcha" data-sitekey="<%= Session("clave_sitio") %>"></div>
							</div>

							<br />
							<!--end::Form group-->
							<!--begin::Action-->
							<div class="pb-lg-0 pb-5">
								<%--<button type="submit" id="kt_login_signin_form_submit_button" class="btn btn-primary fw-bolder fs-6 px-8 py-4 my-3 me-3">Sign In</button>--%>
								<asp:Button ID="btnIniciarSesion" runat="server" Text="Ingresa" class="btn btn-bg-secondary"  TabIndex="3"/>
							<%--	<button type="button" class="btn btn-light-primary fw-bolder px-8 py-4 my-3 fs-6">
								<img src="theme/dist/assets/media/svg/brand-logos/google-icon.svg" class="w-20px h-20px me-3" alt="" />Sign in with Google</button>--%>
							</div>
							<br />

							<asp:Label ID="lblMensajeError" runat="server" Text="" class="form-label fs-7 fw-bolder text-danger pt-8" Visible="false"></asp:Label>
							<br />
							<asp:Label ID="lblMensajeError2" runat="server" Text="" class="form-label fs-7 fw-bolder text-danger pt-8" Visible="false"></asp:Label>
							<!--end::Action-->
						</form>
						<!--end::Signin Form-->
						<!--begin::Signup Form-->
						<form class="form d-none w-100" novalidate="novalidate" id="kt_login_signup_form">
							<!--begin::Title-->
							<div class="pb-5 pb-lg-15">
								<h3 class="fw-bolder text-dark display-6">Sign Up							<p class="text-muted fw-bold fs-3">Enter your details to create your account</p>
							</div>
							<!--end::Title-->
							<!--begin::Form group-->
							<div class="fv-row mb-5">
								<label class="form-label fs-6 fw-bolder text-dark pt-5">Name</label>
								<input class="form-control form-control-lg form-control-solid" type="text" placeholder="" name="fullname" autocomplete="off" />
							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="fv-row mb-5">
								<label class="form-label fs-6 fw-bolder text-dark pt-5">Email</label>
								<input class="form-control form-control-lg form-control-solid" type="email" placeholder="" name="email" autocomplete="off" />
							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="fv-row mb-5">
								<label class="form-label fs-6 fw-bolder text-dark pt-5">Password</label>
								<input class="form-control form-control-lg form-control-solid" type="password" placeholder="" name="password" autocomplete="off" />
							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="fv-row mb-10">
								<label class="form-label fs-6 fw-bolder text-dark pt-5">Confirm Password</label>
								<input class="form-control form-control-lg form-control-solid" type="password" placeholder="" name="cpassword" autocomplete="off" />
							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="fv-row mb-10">
								<div class="form-check form-check-inline form-check-custom form-check-solid mb-5">
									<input class="form-check-input" type="checkbox" name="agree" id="kt_login_toc_agree" value="1" />
									<label class="form-check-label fw-bold text-gray-600" for="kt_login_toc_agree">I Agree the
									<a href="#" class="ms-1">terms and conditions</a>.</label>
								</div>
							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="d-flex flex-wrap pb-lg-0 pb-5">
								<button type="button" id="kt_login_signup_form_submit_button" class="btn btn-primary fw-bolder fs-6 px-8 py-4 my-3 me-4">Submit</button>
								<button type="button" id="kt_login_signup_form_cancel_button" class="btn btn-light-primary fw-bolder fs-6 px-8 py-4 my-3">Cancel</button>
							</div>
							<!--end::Form group-->
						</form>
						<!--end::Signup Form-->
						<!--begin::Password Reset Form-->
						<form class="form d-none w-100" novalidate="novalidate" id="kt_login_password_reset_form">
							<!--begin::Title-->
							<div class="pb-5 pb-lg-10">
								<h3 class="fw-bolder text-dark display-6">Forgotten Password ?</h3>
								<p class="text-muted fw-bold fs-3">Enter your email to reset your password</p>
							</div>
							<!--end::Title-->
							<!--begin::Form group-->
							<div class="fv-row mb-10">
								<label class="form-label fs-6 fw-bolder text-dark pt-5">Email</label>
								<input class="form-control form-control-lg form-control-solid" type="email" placeholder="" name="email" autocomplete="off" />
							</div>
							<!--end::Form group-->
							<!--begin::Form group-->
							<div class="d-flex flex-wrap pb-lg-0">
								<button type="button" id="kt_login_password_reset_form_submit_button" class="btn btn-primary fw-bolder fs-6 px-8 py-4 my-3 me-4">Submit</button>
								<button type="button" id="kt_login_password_reset_form_cancel_button" class="btn btn-light-primary fw-bolder fs-6 px-8 py-4 my-3">Cancel</button>
							</div>
							<!--end::Form group-->
						</form>
						<!--end::Password Reset Form-->
					</div>
					<!--end::Wrapper-->
					<!--begin::Footer-->
					
					<div class="d-flex justify-content-lg-start justify-content-center align-items-center py-2 py-lg-7 py-lg-0 fs-5 fw-bolder">
				
					</div>
			
					<!--end::Footer-->
					
				</div>

				<!--end::Content-->
			</div>
			<!--end::Login-->
		</div>
		
		<!--end::Main-->
		<script>var hostUrl = "theme/dist/assets/";</script>
		<!--begin::Javascript-->
		<!--begin::Global Javascript Bundle(used by all pages)-->
		<script src="theme/dist/assets/plugins/global/plugins.bundle.js"></script>
        
		<script src="theme/dist/assets/js/scripts.bundle.js"></script>
		<!--end::Global Javascript Bundle-->
		<!--begin::Page Custom Javascript(used by this page)-->
		<script src="theme/dist/assets/js/custom/general/login.js"></script>
		<!--end::Page Custom Javascript-->
		<!--end::Javascript-->
	</body>
	<!--end::Body-->
</html>
