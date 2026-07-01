<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="trabajar_inventario.aspx.vb" Inherits="InventarioSAP.trabajar_inventario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es" translate="no">
	<!--begin::Head-->
	<head>
		<title>Sistema de Inventario</title>
		<meta charset="utf-8" />
		<meta name="google" content="notranslate" />
		<meta name="description" content="Check out all the features of the Start admin panel. A large number of templates, components and widgets." />
		<meta name="keywords" content="Start, bootstrap, bootstrap 5, admin themes, free admin themes, bootstrap admin, bootstrap dashboard, html admin theme, html template" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<meta property="og:locale" content="en_US" />
		<meta property="og:type" content="article" />
		<meta property="og:title" content="Start - Bootstrap 5 HTML Multipurpose Admin Dashboard Template" />
		<meta property="og:url" content="https://themes.getbootstrap.com/product/start-multipurpose-admin-dashboard-theme/" />
		<meta property="og:site_name" content="Keenthemes | Start" />
		

		<link rel="canonical" href="https://preview.keenthemes.com/start" />
		<link rel="shortcut icon" href="images/images_sistema/icono.ico" />
			<!--begin::Fonts-->
		<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" />
		<!--end::Fonts-->
		<link href="theme/dist/assets/plugins/custom/leaflet/leaflet.bundle.css" rel="stylesheet" type="text/css" />
		<link href="theme/dist/assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
		<link href="theme/dist/assets/css/style.bundle.css" rel="stylesheet" type="text/css" />
		<script src="assets/libs/jquery/dist/jquery.min.js"></script>
	    <script src="assets/libs/bootstrap/dist/js/bootstrap.min.js"></script>
		
		<link href="theme/dist/assets/plugins/custom/prismjs/prismjs.bundle.css" rel="stylesheet" type="text/css" />
		<link href="theme/dist/assets/plugins/global/plugins.bundle.css" rel="stylesheet" type="text/css" />
		<link href="theme/dist/assets/css/style.bundle.css" rel="stylesheet" type="text/css" />


		<!--end::Global Stylesheets Bundle-->
		<script>
			function CerrarSesion() {
                    var btnCerrarSesion = document.getElementById('<%=btnCerrarSesion.ClientID %>');
                    btnCerrarSesion.click();               
			}

            function NumCheck(e, field) {
                key = e.keyCode ? e.keyCode : e.which
                // backspace
                if (key == 8) return true
                // 0-9
                if (key > 47 && key < 58) {
                    if (field.value == "") return true
                    regexp = /[0-9]{5}$/

                    return !(regexp.test(field.value))
                }
                // .
                if (key == 46) {
                    if (field.value == "") return false
                    regexp = /^[0-9]+$/
                    return regexp.test(field.value)
                }


                // other key
                return false

            }

        </script>
<%--		<script type="text/javascript">
            window.onload = function () {
                document.getElementById('<%= txtdesc_producto.ClientID %>').focus();
            };
        </script>--%>

<style>
input[type="date"] {
    appearance: none;
    -webkit-appearance: none;
    background-color: #f1f1f1;
    padding: 0.75rem;
    border-radius: 0.475rem;
    border: 1px solid #e4e6ef;
    width: 100%;
    color: #181C32;
}
</style>

		<style>
			/*diseño boton delgado*/
.btn-ar-outline {
    background-color: #ffffff !important;   /* fondo blanco */
    border: 1.5px solid #975a89 !important;  /* borde Acurio */
    color: #975a89 !important;

    padding: 0.45rem 0.9rem;
    font-size: 1rem;
    font-weight: 500;

    border-radius: 0.6rem;
    transition: all 0.2s ease-in-out;
}

/* Icono */
.btn-ar-outline i {
    color: #975a89 !important;
    font-size: 1rem;
}

/* Hover / Focus / Active */
.btn-ar-outline:hover,
.btn-ar-outline:focus,
.btn-ar-outline:active {
    background-color: #975a89 !important;
    color: #ffffff !important;
    border-color: #975a89 !important;
    box-shadow: none !important;
}

.btn-ar-outline:hover i,
.btn-ar-outline:focus i,
.btn-ar-outline:active i {
    color: #ffffff !important;
}


/*grilla resaltado*/
/* Hover filas GridView - Acurio */
#grvinventariados tbody tr:hover {
    background-color: rgba(151, 90, 137, 0.12) !important; /* Acurio suave */
    transition: background-color 0.15s ease-in-out;
}

/* Mantener texto legible */
#grvinventariados tbody tr:hover td {
    color: #540f4a; /* morado más oscuro */
}

/* Opcional: iconos dentro de la fila */
#grvinventariados tbody tr:hover i {
    color: #975a89;
}




		</style>

	</head>
	<!--end::Head-->
	<!--begin::Body-->
	<body id="kt_body" class="header-fixed header-tablet-and-mobile-fixed aside-enabled aside-fixed aside-primary-enabled aside-secondary-enabled" translate="no">
		<div class="d-flex flex-column flex-root">
			<!--begin::Page-->
			<div class="page d-flex flex-row flex-column-fluid">
				<!--begin::Aside-->
				<div id="kt_aside" class="aside bg-info" data-kt-drawer="true" data-kt-drawer-name="aside" data-kt-drawer-activate="{default: true, lg: false}" data-kt-drawer-overlay="true" data-kt-drawer-width="{default:'200px', '300px': '250px'}" data-kt-drawer-direction="start" data-kt-drawer-toggle="#kt_aside_toggler">
					<!--begin::Primary-->
					<div class="aside-primary d-flex flex-column align-items-center flex-row-auto" style="background-color: #540f4a">
						<!--begin::Logo-->
						<div class="aside-logo d-flex flex-column align-items-center flex-column-auto py-4 pt-lg-10 pb-lg-7" id="kt_aside_logo" >
							<a href="main.aspx">
								<img alt="Logo" src="images/sap.ico" class="mh-50px" />
							</a>
							<br/>
							<a href="main.aspx">
								<img alt="Logo" src="images/AR.ico" class="mh-50px" />
							</a>
						</div>
						<!--end::Logo-->
						<!--begin::Nav Wrapper-->
						<div class="aside-nav d-flex flex-column align-items-center flex-column-fluid pt-0 pb-5" id="kt_aside_nav">
							<!--begin::Nav scroll-->
							<div class="hover-scroll-y" data-kt-scroll="true" data-kt-scroll-height="auto" data-kt-scroll-dependencies="#kt_aside_logo, #kt_aside_footer" data-kt-scroll-wrappers="#kt_aside_nav" data-kt-scroll-offset="10px">

							</div>
							<!--end::Nav scroll-->
						</div>
						<!--end::Nav Wrapper-->
						<!--begin::Footer-->
						<div class="aside-footer d-flex flex-column align-items-center flex-column-auto py-5 py-lg-7" id="kt_aside_footer">
							<!--begin::Aside Toggle-->
							<button class="btn btn-sm btn-icon btn-white btn-active-primary position-absolute translate-middle start-100 end-0 bottom-0 shadow-sm d-none d-lg-flex" id="kt_aside_toggle" data-kt-toggle="true" data-kt-toggle-state="active" data-kt-toggle-target="body" data-kt-toggle-name="aside-minimize" title="Toggle Aside">
								<!--begin::Svg Icon | path: icons/duotune/arrows/arr063.svg-->
								<span class="svg-icon svg-icon-2 rotate-180">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
										<rect opacity="0.5" x="6" y="11" width="13" height="2" rx="1" fill="black" />
										<path d="M8.56569 11.4343L12.75 7.25C13.1642 6.83579 13.1642 6.16421 12.75 5.75C12.3358 5.33579 11.6642 5.33579 11.25 5.75L5.70711 11.2929C5.31658 11.6834 5.31658 12.3166 5.70711 12.7071L11.25 18.25C11.6642 18.6642 12.3358 18.6642 12.75 18.25C13.1642 17.8358 13.1642 17.1642 12.75 16.75L8.56569 12.5657C8.25327 12.2533 8.25327 11.7467 8.56569 11.4343Z" fill="black" />
									</svg>
								</span>
								<!--end::Svg Icon-->
							</button>
							<!--end::Aside Toggle-->
							<!--begin::Menu-->
							<div class="mb-2" data-bs-toggle="tooltip" data-bs-placement="right" data-bs-trigger="hover" title="Quick settings">
								<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold w-200px" data-kt-menu="true">
									<div class="menu-item px-3">
										<div class="menu-content fs-6 text-dark fw-bolder px-3 py-4">Manage</div>
									</div>
									<div class="separator mb-3 opacity-75"></div>
									<div class="menu-item px-3">
										<a href="#" class="menu-link px-3">Add User</a>
									</div>
									<div class="menu-item px-3">
										<a href="#" class="menu-link px-3">Add Role</a>
									</div>
									<div class="menu-item px-3" data-kt-menu-trigger="hover" data-kt-menu-placement="right-start" data-kt-menu-flip="left-start, top">
										<a href="#" class="menu-link px-3">
											<span class="menu-title">Add Group</span>
											<span class="menu-arrow"></span>
										</a>
										<div class="menu-sub menu-sub-dropdown w-200px py-4">
											<div class="menu-item px-3">
												<a href="#" class="menu-link px-3">Admin Group</a>
											</div>
											<div class="menu-item px-3">
												<a href="#" class="menu-link px-3">Staff Group</a>
											</div>
											<div class="menu-item px-3">
												<a href="#" class="menu-link px-3">Member Group</a>
											</div>
										</div>
									</div>
									<div class="menu-item px-3">
										<a href="#" class="menu-link px-3">Reports</a>
									</div>
									<div class="separator mt-3 opacity-75"></div>
									<div class="menu-item px-3">
										<div class="menu-content px-3 py-3">
											<a class="btn btn-primary fw-bold btn-sm px-4" href="#">Create New</a>
										</div>
									</div>
								</div>
								<!--end::Menu-->
							</div>
							<!--end::Menu-->
						</div>
						<!--end::Footer-->
					</div>
					<!--end::Primary-->
					<!--begin::Secondary-->
					<div class="aside-secondary d-flex flex-row-fluid bg-white">
						<!--begin::Workspace-->
						<div class="aside-workspace my-7 ps-5 pe-4 ps-lg-10 pe-lg-6" id="kt_aside_wordspace">
							<!--begin::Tab Content-->
							<div class="tab-content">
								<!--begin::Main menu-->
								<div class="tab-pane fade show active" id="kt_aside_tab_1">
									<!--begin::Aside Menu-->
									<!--begin::Menu-->
									<div class="menu menu-column menu-rounded menu-title-gray-700 menu-state-title-primary menu-state-icon-primary menu-state-bullet-primary menu-arrow-gray-500 fw-bold fs-6" data-kt-menu="true">
										<div class="hover-scroll-y pe-4 pe-lg-5" id="kt_aside_menu_scroll" data-kt-scroll="true" data-kt-scroll-height="auto" data-kt-scroll-wrappers="#kt_aside_wordspace" data-kt-scroll-offset="10px">
											<div class="menu-wrapper menu-column menu-fit">
												<div class="menu-item here show">
													<h4 class="menu-content text-muted mb-0 fs-6 fw-bold text-uppercase">Sistema de Inventario</h4>
													<div class="menu-sub menu-fit menu-sub-accordion show pb-10">
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Menú Principal</span>
															</a>
														</div>
														<%--<div class="menu-item">
															<a class="menu-link active py-2" href="../dist/dashboards/extended.html">
																<span class="menu-title">Extended</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="../dist/dashboards/light.html">
																<span class="menu-title">Light</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="../dist/dashboards/compact.html">
																<span class="menu-title">Compact</span>
															</a>
														</div>--%>
													</div>
												</div>
<%--												<div class="menu-item">
													<h4 class="menu-content text-muted mb-0 fs-6 fw-bold text-uppercase">Opciones</h4>
													<div class="menu-sub menu-fit menu-sub-accordion show pb-10">
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Administrador Inventarios</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Nuevo Inventario</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Trabajar Inventario...</span>
															</a>
														</div>
														
													
													</div>
												</div>--%>
												<%--<div class="menu-item">
													<h4 class="menu-content text-muted mb-0 fs-6 fw-bold text-uppercase">Mantenimiento</h4>
													<div class="menu-sub menu-fit menu-sub-accordion show pb-10">
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Empresa</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Marca</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Unidad</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Motivos</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Categoría 1</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Tipo 1</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Categoría 2</span>
															</a>
														</div>
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Tipo 2</span>
															</a>
														</div>
													</div>
												</div>--%>
<%--												<div class="menu-item">
													<h4 class="menu-content text-muted mb-0 fs-6 fw-bold text-uppercase">Profile</h4>
													<div class="menu-sub menu-fit menu-sub-accordion show pb-10">
														<div class="menu-item">
															<a class="menu-link py-2" href="main.aspx">
																<span class="menu-title">Datos Usuario</span>
															</a>
														</div>
													
													</div>
												</div>--%>
												
											</div>
										</div>
									</div>
									<!--end::Menu-->
								</div>
								<!--end::Main menu-->
								<!--begin::Demo menu-->
								<div class="tab-pane fade" id="kt_aside_tab_2">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</div>
								<!--end::Demo menu-->
								<!--begin::Demo menu-->
								<div class="tab-pane fade" id="kt_aside_tab_3">Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</div>
								<!--end::Demo menu-->
							</div>
							<!--end::Tab Content-->
						</div>
						<!--end::Workspace-->
					</div>
					<!--end::Secondary-->
				</div>
				<!--end::Aside-->
				<!--begin::Wrapper-->
				<div class="wrapper d-flex flex-column flex-row-fluid" id="kt_wrapper">
					<form  runat="server" translate="no">
						<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
						<asp:Button ID="btnCerrarSesion" runat="server" Text="Button"  style="display:none;" />
					<!--begin::Header-->
					<div id="kt_header" class="header" data-kt-sticky="true" data-kt-sticky-name="header" data-kt-sticky-offset="{default: '200px', lg: '300px'}">
						<!--begin::Container-->
						<div class="container-xxl d-flex align-items-stretch justify-content-between">
							<!--begin::Left-->
							<div class="d-flex align-items-center">
								<!--begin::Title-->
								<h3 class="text-dark fw-bolder my-1 fs-2">Trabajar Inventario...</h3>
								<!--end::Title-->
							</div>
							<!--end::Left-->
							<!--begin::Right-->
							<div class="d-flex align-items-center">
								<!--begin::Search-->
							<%--	<button class="btn btn-icon btn-sm btn-active-bg-accent ms-1 ms-lg-6" data-bs-toggle="modal" data-bs-target="#kt_header_search_modal" id="kt_header_search_toggle">
									<!--begin::Svg Icon | path: icons/duotune/general/gen021.svg-->
									<span class="svg-icon svg-icon-1 svg-icon-dark">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="black" />
											<path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="black" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</button>--%>
								<!--end::Search-->
								<!--begin::Message-->
							<%--	<button class="btn btn-icon btn-sm btn-active-bg-accent ms-1 ms-lg-6" id="kt_drawer_chat_toggle">
									<!--begin::Svg Icon | path: icons/duotune/communication/com003.svg-->
									<span class="svg-icon svg-icon-1 svg-icon-dark">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<path opacity="0.3" d="M2 4V16C2 16.6 2.4 17 3 17H13L16.6 20.6C17.1 21.1 18 20.8 18 20V17H21C21.6 17 22 16.6 22 16V4C22 3.4 21.6 3 21 3H3C2.4 3 2 3.4 2 4Z" fill="black" />
											<path d="M18 9H6C5.4 9 5 8.6 5 8C5 7.4 5.4 7 6 7H18C18.6 7 19 7.4 19 8C19 8.6 18.6 9 18 9ZM16 12C16 11.4 15.6 11 15 11H6C5.4 11 5 11.4 5 12C5 12.6 5.4 13 6 13H15C15.6 13 16 12.6 16 12Z" fill="black" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</button>--%>
								<!--end::Message-->
								<!--begin::User-->
								<div class="ms-1 ms-lg-6">
									<!--begin::Toggle-->
									<div class="btn btn-icon btn-sm btn-active-bg-accent" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" id="kt_header_user_menu_toggle">
										<!--begin::Svg Icon | path: icons/duotune/communication/com013.svg-->
										<span class="svg-icon svg-icon-1 svg-icon-dark">
											<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
												<path d="M6.28548 15.0861C7.34369 13.1814 9.35142 12 11.5304 12H12.4696C14.6486 12 16.6563 13.1814 17.7145 15.0861L19.3493 18.0287C20.0899 19.3618 19.1259 21 17.601 21H6.39903C4.87406 21 3.91012 19.3618 4.65071 18.0287L6.28548 15.0861Z" fill="black" />
												<rect opacity="0.3" x="8" y="3" width="8" height="8" rx="4" fill="black" />
											</svg>
										</span>
										<!--end::Svg Icon-->
									</div>
									<!--begin::Menu-->
									<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-600 menu-state-bg-light-primary fw-bold w-300px" data-kt-menu="true" >
										<div class="menu-content fw-bold d-flex align-items-center bgi-no-repeat bgi-position-y-top rounded-top" style="background-image:url('assets/media//misc/dropdown-header-bg.jpg')">
											<div class="symbol symbol-45px mx-5 py-5">
												<span class="symbol-label bg-primary align-items-end" style="background-color: #FF00FF">
													<img alt="Logo" src="theme/dist/assets/media/svg/avatars/001-boy.svg" class="mh-35px" />
												</span>
											</div>
											<div class="">
												<span class="text-white fw-bolder fs-4">Usuario</span>
												<span class="text-white fw-bold fs-7 d-block">AR</span>
											</div>
										</div>
										<!--begin::Row-->
										<div class="row row-cols-2 g-0">
											<a href="main.aspx" class="border-bottom border-end text-center py-10 btn btn-active-color-primary rounded-0">
												<!--begin::Svg Icon | path: icons/duotune/general/gen025.svg-->
												<span class="svg-icon svg-icon-3x me-n1">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<rect x="2" y="2" width="9" height="9" rx="2" fill="black" />
														<rect opacity="0.3" x="13" y="2" width="9" height="9" rx="2" fill="black" />
														<rect opacity="0.3" x="13" y="13" width="9" height="9" rx="2" fill="black" />
														<rect opacity="0.3" x="2" y="13" width="9" height="9" rx="2" fill="black" />
													</svg>
												</span>
												<!--end::Svg Icon-->
												<span class="fw-bolder fs-6 d-block pt-3">Mi Perfil</span>
											</a>
											<a href="main.aspx" class="col border-bottom text-center py-10 btn btn-active-color-primary rounded-0">
												<!--begin::Svg Icon | path: icons/duotune/general/gen019.svg-->
												<span class="svg-icon svg-icon-3x me-n1">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path d="M17.5 11H6.5C4 11 2 9 2 6.5C2 4 4 2 6.5 2H17.5C20 2 22 4 22 6.5C22 9 20 11 17.5 11ZM15 6.5C15 7.9 16.1 9 17.5 9C18.9 9 20 7.9 20 6.5C20 5.1 18.9 4 17.5 4C16.1 4 15 5.1 15 6.5Z" fill="black" />
														<path opacity="0.3" d="M17.5 22H6.5C4 22 2 20 2 17.5C2 15 4 13 6.5 13H17.5C20 13 22 15 22 17.5C22 20 20 22 17.5 22ZM4 17.5C4 18.9 5.1 20 6.5 20C7.9 20 9 18.9 9 17.5C9 16.1 7.9 15 6.5 15C5.1 15 4 16.1 4 17.5Z" fill="black" />
													</svg>
												</span>
												<!--end::Svg Icon-->
												<span class="fw-bolder fs-6 d-block pt-3">Herramientas</span>
											</a>
											<a href="main.aspx" class="col text-center border-end py-10 btn btn-active-color-primary rounded-0">
												<!--begin::Svg Icon | path: icons/duotune/finance/fin009.svg-->
												<span class="svg-icon svg-icon-3x me-n1">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<path opacity="0.3" d="M15.8 11.4H6C5.4 11.4 5 11 5 10.4C5 9.80002 5.4 9.40002 6 9.40002H15.8C16.4 9.40002 16.8 9.80002 16.8 10.4C16.8 11 16.3 11.4 15.8 11.4ZM15.7 13.7999C15.7 13.1999 15.3 12.7999 14.7 12.7999H6C5.4 12.7999 5 13.1999 5 13.7999C5 14.3999 5.4 14.7999 6 14.7999H14.8C15.3 14.7999 15.7 14.2999 15.7 13.7999Z" fill="black" />
														<path d="M18.8 15.5C18.9 15.7 19 15.9 19.1 16.1C19.2 16.7 18.7 17.2 18.4 17.6C17.9 18.1 17.3 18.4999 16.6 18.7999C15.9 19.0999 15 19.2999 14.1 19.2999C13.4 19.2999 12.7 19.2 12.1 19.1C11.5 19 11 18.7 10.5 18.5C10 18.2 9.60001 17.7999 9.20001 17.2999C8.80001 16.8999 8.49999 16.3999 8.29999 15.7999C8.09999 15.1999 7.80001 14.7 7.70001 14.1C7.60001 13.5 7.5 12.8 7.5 12.2C7.5 11.1 7.7 10.1 8 9.19995C8.3 8.29995 8.79999 7.60002 9.39999 6.90002C9.99999 6.30002 10.7 5.8 11.5 5.5C12.3 5.2 13.2 5 14.1 5C15.2 5 16.2 5.19995 17.1 5.69995C17.8 6.09995 18.7 6.6 18.8 7.5C18.8 7.9 18.6 8.29998 18.3 8.59998C18.2 8.69998 18.1 8.69993 18 8.79993C17.7 8.89993 17.4 8.79995 17.2 8.69995C16.7 8.49995 16.5 7.99995 16 7.69995C15.5 7.39995 14.9 7.19995 14.2 7.19995C13.1 7.19995 12.1 7.6 11.5 8.5C10.9 9.4 10.5 10.6 10.5 12.2C10.5 13.3 10.7 14.2 11 14.9C11.3 15.6 11.7 16.1 12.3 16.5C12.9 16.9 13.5 17 14.2 17C15 17 15.7 16.8 16.2 16.4C16.8 16 17.2 15.2 17.9 15.1C18 15 18.5 15.2 18.8 15.5Z" fill="black" />
													</svg>
												</span>
												<!--end::Svg Icon-->
												<span class="fw-bolder fs-6 d-block pt-3">Otros</span>
											</a>
											<a href="javascript:CerrarSesion();" class="col text-center py-10 btn btn-active-color-primary rounded-0">
												<!--begin::Svg Icon | path: icons/duotune/arrows/arr077.svg-->
												<span class="svg-icon svg-icon-3x me-n1">
													<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
														<rect opacity="0.3" x="4" y="11" width="12" height="2" rx="1" fill="black" />
														<path d="M5.86875 11.6927L7.62435 10.2297C8.09457 9.83785 8.12683 9.12683 7.69401 8.69401C7.3043 8.3043 6.67836 8.28591 6.26643 8.65206L3.34084 11.2526C2.89332 11.6504 2.89332 12.3496 3.34084 12.7474L6.26643 15.3479C6.67836 15.7141 7.3043 15.6957 7.69401 15.306C8.12683 14.8732 8.09458 14.1621 7.62435 13.7703L5.86875 12.3073C5.67684 12.1474 5.67684 11.8526 5.86875 11.6927Z" fill="black" />
														<path d="M8 5V6C8 6.55228 8.44772 7 9 7C9.55228 7 10 6.55228 10 6C10 5.44772 10.4477 5 11 5H18C18.5523 5 19 5.44772 19 6V18C19 18.5523 18.5523 19 18 19H11C10.4477 19 10 18.5523 10 18C10 17.4477 9.55228 17 9 17C8.44772 17 8 17.4477 8 18V19C8 20.1046 8.89543 21 10 21H19C20.1046 21 21 20.1046 21 19V5C21 3.89543 20.1046 3 19 3H10C8.89543 3 8 3.89543 8 5Z" fill="#C4C4C4" />
													</svg>
												</span>
												<!--end::Svg Icon-->
												<span class="fw-bolder fs-6 d-block pt-3">Salir</span>
											</a>
										</div>
										<!--end::Row-->
									</div>
									<!--end::Menu-->
								</div>
								<!--end::User-->
								<!--begin::Notifications-->
								<div class="ms-1 ms-lg-6">
									<!--begin::Dropdown-->
									<%--<button class="btn btn-icon btn-sm btn-light-danger fw-bolder pulse pulse-danger" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end" id="kt_activities_toggle">
										<span class="position-absolute fs-6">3</span>
										<span class="pulse-ring"></span>
									</button>--%>
									<!--begin::Menu-->
									<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded fw-bold menu-title-gray-800 menu-hover-bg menu-state-title-primary w-250px w-md-300px" data-kt-menu="true">
										<div class="menu-item mx-3">
											<div class="menu-content fs-6 text-dark fw-bolder py-6">4 New Notifications</div>
										</div>
										<div class="separator mb-3"></div>
										<div class="menu-item mx-3">
											<a href="#" class="menu-link px-4 py-3">
												<div class="symbol symbol-35px">
													<span class="symbol-label bg-light-info">
														<!--begin::Svg Icon | path: icons/duotune/abstract/abs027.svg-->
														<span class="svg-icon svg-icon-3 svg-icon-info">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<path opacity="0.3" d="M21.25 18.525L13.05 21.825C12.35 22.125 11.65 22.125 10.95 21.825L2.75 18.525C1.75 18.125 1.75 16.725 2.75 16.325L4.04999 15.825L10.25 18.325C10.85 18.525 11.45 18.625 12.05 18.625C12.65 18.625 13.25 18.525 13.85 18.325L20.05 15.825L21.35 16.325C22.35 16.725 22.35 18.125 21.25 18.525ZM13.05 16.425L21.25 13.125C22.25 12.725 22.25 11.325 21.25 10.925L13.05 7.62502C12.35 7.32502 11.65 7.32502 10.95 7.62502L2.75 10.925C1.75 11.325 1.75 12.725 2.75 13.125L10.95 16.425C11.65 16.725 12.45 16.725 13.05 16.425Z" fill="black" />
																<path d="M11.05 11.025L2.84998 7.725C1.84998 7.325 1.84998 5.925 2.84998 5.525L11.05 2.225C11.75 1.925 12.45 1.925 13.15 2.225L21.35 5.525C22.35 5.925 22.35 7.325 21.35 7.725L13.05 11.025C12.45 11.325 11.65 11.325 11.05 11.025Z" fill="black" />
															</svg>
														</span>
														<!--end::Svg Icon-->
													</span>
												</div>
												<div class="ps-4">
													<span class="menu-title fw-bold mb-1">New Uer Library Added</span>
													<span class="text-muted fw-bold d-block fs-7">3 Hours ago</span>
												</div>
											</a>
										</div>
										<div class="menu-item mx-3">
											<a href="#" class="menu-link px-4 py-3">
												<div class="symbol symbol-35px">
													<span class="symbol-label bg-light-warning">
														<!--begin::Svg Icon | path: icons/duotune/communication/com004.svg-->
														<span class="svg-icon svg-icon-3 svg-icon-warning">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<path opacity="0.3" d="M14 3V20H2V3C2 2.4 2.4 2 3 2H13C13.6 2 14 2.4 14 3ZM11 13V11C11 9.7 10.2 8.59995 9 8.19995V7C9 6.4 8.6 6 8 6C7.4 6 7 6.4 7 7V8.19995C5.8 8.59995 5 9.7 5 11V13C5 13.6 4.6 14 4 14V15C4 15.6 4.4 16 5 16H11C11.6 16 12 15.6 12 15V14C11.4 14 11 13.6 11 13Z" fill="black" />
																<path d="M2 20H14V21C14 21.6 13.6 22 13 22H3C2.4 22 2 21.6 2 21V20ZM9 3V2H7V3C7 3.6 7.4 4 8 4C8.6 4 9 3.6 9 3ZM6.5 16C6.5 16.8 7.2 17.5 8 17.5C8.8 17.5 9.5 16.8 9.5 16H6.5ZM21.7 12C21.7 11.4 21.3 11 20.7 11H17.6C17 11 16.6 11.4 16.6 12C16.6 12.6 17 13 17.6 13H20.7C21.2 13 21.7 12.6 21.7 12ZM17 8C16.6 8 16.2 7.80002 16.1 7.40002C15.9 6.90002 16.1 6.29998 16.6 6.09998L19.1 5C19.6 4.8 20.2 5 20.4 5.5C20.6 6 20.4 6.60005 19.9 6.80005L17.4 7.90002C17.3 8.00002 17.1 8 17 8ZM19.5 19.1C19.4 19.1 19.2 19.1 19.1 19L16.6 17.9C16.1 17.7 15.9 17.1 16.1 16.6C16.3 16.1 16.9 15.9 17.4 16.1L19.9 17.2C20.4 17.4 20.6 18 20.4 18.5C20.2 18.9 19.9 19.1 19.5 19.1Z" fill="black" />
															</svg>
														</span>
														<!--end::Svg Icon-->
													</span>
												</div>
												<div class="ps-4">
													<span class="menu-title fw-bold mb-1">Clean Microphone</span>
													<span class="text-muted fw-bold d-block fs-7">5 Hours ago</span>
												</div>
											</a>
										</div>
										<div class="menu-item mx-3">
											<a href="#" class="menu-link px-4 py-3">
												<div class="symbol symbol-35px">
													<span class="symbol-label bg-light-primary">
														<!--begin::Svg Icon | path: icons/duotune/communication/com012.svg-->
														<span class="svg-icon svg-icon-3 svg-icon-primary">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<path opacity="0.3" d="M20 3H4C2.89543 3 2 3.89543 2 5V16C2 17.1046 2.89543 18 4 18H4.5C5.05228 18 5.5 18.4477 5.5 19V21.5052C5.5 22.1441 6.21212 22.5253 6.74376 22.1708L11.4885 19.0077C12.4741 18.3506 13.6321 18 14.8167 18H20C21.1046 18 22 17.1046 22 16V5C22 3.89543 21.1046 3 20 3Z" fill="black" />
																<rect x="6" y="12" width="7" height="2" rx="1" fill="black" />
																<rect x="6" y="7" width="12" height="2" rx="1" fill="black" />
															</svg>
														</span>
														<!--end::Svg Icon-->
													</span>
												</div>
												<div class="ps-4">
													<span class="menu-title fw-bold mb-1">Quick Chat Created</span>
													<span class="text-muted fw-bold d-block fs-7">A Day ago</span>
												</div>
											</a>
										</div>
										<div class="menu-item mx-3">
											<a href="#" class="menu-link px-4 py-3">
												<div class="symbol symbol-35px">
													<span class="symbol-label bg-light-danger">
														<!--begin::Svg Icon | path: icons/duotune/coding/cod008.svg-->
														<span class="svg-icon svg-icon-3 svg-icon-danger">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<path d="M11.2166 8.50002L10.5166 7.80007C10.1166 7.40007 10.1166 6.80005 10.5166 6.40005L13.4166 3.50002C15.5166 1.40002 18.9166 1.50005 20.8166 3.90005C22.5166 5.90005 22.2166 8.90007 20.3166 10.8001L17.5166 13.6C17.1166 14 16.5166 14 16.1166 13.6L15.4166 12.9C15.0166 12.5 15.0166 11.9 15.4166 11.5L18.3166 8.6C19.2166 7.7 19.1166 6.30002 18.0166 5.50002C17.2166 4.90002 16.0166 5.10007 15.3166 5.80007L12.4166 8.69997C12.2166 8.89997 11.6166 8.90002 11.2166 8.50002ZM11.2166 15.6L8.51659 18.3001C7.81659 19.0001 6.71658 19.2 5.81658 18.6C4.81658 17.9 4.71659 16.4 5.51659 15.5L8.31658 12.7C8.71658 12.3 8.71658 11.7001 8.31658 11.3001L7.6166 10.6C7.2166 10.2 6.6166 10.2 6.2166 10.6L3.6166 13.2C1.7166 15.1 1.4166 18.1 3.1166 20.1C5.0166 22.4 8.51659 22.5 10.5166 20.5L13.3166 17.7C13.7166 17.3 13.7166 16.7001 13.3166 16.3001L12.6166 15.6C12.3166 15.2 11.6166 15.2 11.2166 15.6Z" fill="black" />
																<path opacity="0.3" d="M5.0166 9L2.81659 8.40002C2.31659 8.30002 2.0166 7.79995 2.1166 7.19995L2.31659 5.90002C2.41659 5.20002 3.21659 4.89995 3.81659 5.19995L6.0166 6.40002C6.4166 6.60002 6.6166 7.09998 6.5166 7.59998L6.31659 8.30005C6.11659 8.80005 5.5166 9.1 5.0166 9ZM8.41659 5.69995H8.6166C9.1166 5.69995 9.5166 5.30005 9.5166 4.80005L9.6166 3.09998C9.6166 2.49998 9.2166 2 8.5166 2H7.81659C7.21659 2 6.71659 2.59995 6.91659 3.19995L7.31659 4.90002C7.41659 5.40002 7.91659 5.69995 8.41659 5.69995ZM14.6166 18.2L15.1166 21.3C15.2166 21.8 15.7166 22.2 16.2166 22L17.6166 21.6C18.1166 21.4 18.4166 20.8 18.1166 20.3L16.7166 17.5C16.5166 17.1 16.1166 16.9 15.7166 17L15.2166 17.1C14.8166 17.3 14.5166 17.7 14.6166 18.2ZM18.4166 16.3L19.8166 17.2C20.2166 17.5 20.8166 17.3 21.0166 16.8L21.3166 15.9C21.5166 15.4 21.1166 14.8 20.5166 14.8H18.8166C18.0166 14.8 17.7166 15.9 18.4166 16.3Z" fill="black" />
															</svg>
														</span>
														<!--end::Svg Icon-->
													</span>
												</div>
												<div class="ps-4">
													<span class="menu-title fw-bold mb-1">32 New Attachements</span>
													<span class="text-muted fw-bold d-block fs-7">2 Day ago</span>
												</div>
											</a>
										</div>
										<div class="separator mt-3"></div>
										<div class="menu-item mx-2">
											<div class="menu-content py-5">
												<a href="#" class="btn btn-primary fw-bolder me-2 px-5">Report</a>
												<a href="#" class="btn btn-light fw-bolder px-5">Reset</a>
											</div>
										</div>
									</div>
									<!--end::Menu-->
									<!--end::Dropdown-->
								</div>
								<!--end::Notifications-->
								<!--begin::Aside Toggler-->
								<button class="btn btn-icon btn-sm btn-active-bg-accent d-lg-none ms-1 ms-lg-6" id="kt_aside_toggler">
									<!--begin::Svg Icon | path: icons/duotune/abstract/abs015.svg-->
									<span class="svg-icon svg-icon-1 svg-icon-dark">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<path d="M21 7H3C2.4 7 2 6.6 2 6V4C2 3.4 2.4 3 3 3H21C21.6 3 22 3.4 22 4V6C22 6.6 21.6 7 21 7Z" fill="black" />
											<path opacity="0.3" d="M21 14H3C2.4 14 2 13.6 2 13V11C2 10.4 2.4 10 3 10H21C21.6 10 22 10.4 22 11V13C22 13.6 21.6 14 21 14ZM22 20V18C22 17.4 21.6 17 21 17H3C2.4 17 2 17.4 2 18V20C2 20.6 2.4 21 3 21H21C21.6 21 22 20.6 22 20Z" fill="black" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</button>
								<!--end::Aside Toggler-->
								<!--begin::Sidebar Toggler-->
								<!--end::Sidebar Toggler-->
							</div>
							<!--end::Right-->
						</div>
						<!--end::Container-->
					</div>
					<!--end::Header-->
					<!--begin::Main-->
					<div class="d-flex flex-column flex-column-fluid">
						<!--begin::Content-->
						<div class="content fs-6 d-flex flex-column-fluid" id="kt_content">
							<!--begin::Container-->
							<div class="container-xxl">
							<!--begin::Row-->
								<div class="d-flex bg-light-dark card-rounded flex-grow-1">
												<!--begin::Section-->
												<div class="py-10 ps-7">
													<!--begin::Text-->
													<div class="">
														<span class="text-primary d-block mb-n1"><asp:Label ID="lblmensaje_inv_activo_d" runat="server" Text=""></asp:Label></span>
														<span class="font-weight-light fs-1 text-gray-800">cantidad de Registros inventariados
														<span class="fw-bolder fs-1 text-gray-800"><asp:Label ID="lblcanregistros_inv_d" runat="server" Text=""></asp:Label></span></span>
														<asp:Label ID="lblid_inventario" runat="server" Text="" Visible="False"></asp:Label>
													</div>
													<p></p>
													<!--end::Text-->
												    <asp:LinkButton 
														ID="btnBuscarProducto"
														runat="server"
														CssClass="btn btn-ar-outline d-inline-flex align-items-center gap-2">
    
														<i class="fas fa-search"></i>
														<span>Buscar Producto</span>

													</asp:LinkButton>

													<asp:LinkButton 
																	ID="btnInventariados"
																	runat="server"
																	CssClass="btn btn-ar-outline d-inline-flex align-items-center gap-2">
    
																	<i class="fas fa-search"></i>
																	<span>Inventariados</span>

													</asp:LinkButton>

													<asp:LinkButton 
																ID="btnLimpiar"
																runat="server"
																CssClass="btn btn-ar-outline d-inline-flex align-items-center gap-2">
    
																<i class="fas fa-search"></i>
																<span>Limpiar campos</span>

													</asp:LinkButton>



<%--													<asp:LinkButton ID="btnBuscarProducto" runat="server" class="btn btn-primary btn-sm fw-bolder fs-6 ps-4 mt-6">Buscar Producto</asp:LinkButton>--%>
													<%--<asp:LinkButton ID="btnInventariados" runat="server" class="btn btn-primary btn-sm fw-bolder fs-6 ps-4 mt-6">Inventariados</asp:LinkButton>--%>
													<%--<asp:LinkButton ID="btnLimpiar" runat="server" class="btn btn-primary btn-sm fw-bolder fs-6 ps-4 mt-6">Limpiar Campos</asp:LinkButton>--%>
													<%--<asp:LinkButton ID="btnTrabajarInventario" runat="server" class="btn btn-primary btn-sm fw-bolder fs-6 ps-4 mt-6">Registrar Cantidad</asp:LinkButton>--%>

												</div>
												<!--end::Section-->
												<!--begin::Pic-->
												<%--<div class="position-relative bgi-no-repeat bgi-size-contain bgi-position-y-bottom bgi-position-x-end mt-6 flex-grow-1" style="background-image:url('theme/dist/assets/media/misc/illustration-1.png')"></div>--%>
												<!--end::Pic-->
											</div>
								<br />
							
								<div class="modal-body">
											
											
									
									<div class="row mb-8">
										<div class="col-lg-3">
											<label class="col-form-label">Código de Producto:</label>
										</div>
										<div class="col-lg-6">
											<div class="spinner spinner-sm spinner-primary spinner-right">
												<asp:Panel ID="Panel2" runat="server" DefaultButton="otroBoton">
													<asp:TextBox ID="txtcodigo_producto" runat="server" class="form-control" ></asp:TextBox>
												</asp:Panel>
											</div>
										</div>
									</div>

									<div class="row mb-8">
										<div class="col-lg-3">
											<label class="col-form-label">Descripción del producto:</label>
										</div>
										<div class="col-lg-6 d-flex align-items-end">
											<div class="spinner spinner-sm spinner-primary spinner-right flex-grow-1">
												<asp:Panel ID="Panel1" runat="server" DefaultButton="otroBoton">
													<asp:TextBox ID="txtdesc_producto" runat="server" class="form-control"></asp:TextBox>
												</asp:Panel>
											</div>
										</div>
										<div class="col-lg-3">
											<asp:Button ID="otroBoton" runat="server" Style="display: none;" Text="OtroBoton" />
											<%--<asp:LinkButton ID="btnBuscarProducto2" runat="server" class="btn btn-primary btn-sm fw-bolder fs-6 ps-4">Buscar Producto</asp:LinkButton>--%>
											<asp:LinkButton 
												ID="btnBuscarProducto2"
												runat="server"
												CssClass="btn btn-ar-outline d-inline-flex align-items-center gap-2">
    
												<i class="fas fa-search"></i>
												<span>Buscar Producto</span>

											</asp:LinkButton>

										</div>
									</div>


											<hr />
										
											<div class="row mb-8">
												<label class="col-lg-3 col-form-label">Seleccione Almacén (Zona)*:</label>
													<div class="col-lg-6">
													<asp:UpdatePanel ID="UpdatePanel11" runat="server">
														<ContentTemplate>
															<asp:DropDownList ID="cbozona" runat="server" class="form-select form-select-lg form-select-solid" AutoPostBack="True"></asp:DropDownList>
														</ContentTemplate>
													</asp:UpdatePanel>
													
												    </div>
											</div>

										<div class="pb-10">
										<!--begin::Heading-->
										<h1 class="anchor fw-bolder mb-5" id="basic-table">
										<a href="#basic-table"></a>Listado de Productos a inventariar</h1>

										<div class="my-5">

												<%--lista de productos--%>
														
															<asp:GridView ID="grvProductos" runat="server" class="table product-overview" AutoGenerateColumns="False" AllowSorting="True">
															  <Columns>
                                       
																   <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60">
															   <ItemTemplate>
																   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
																	   <ContentTemplate>
																		   <table>
																			   <tr>
																				   <td>
																					   &nbsp;<asp:LinkButton ID="btnInventariar" runat="server" class="btn waves-effect waves-light btn-rounded btn-light" CommandName="inventariar" CommandArgument='<%# Bind("material") %>'>Inventariar</asp:LinkButton>
																				   </td>
																			   </tr>
																		   </table>
																		   
																	   </ContentTemplate>
																   </asp:UpdatePanel>
																	
                                               
															   </ItemTemplate>
                    
																	   <HeaderStyle BackColor="" ForeColor="Black" />
																	   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>
                                       

														   <asp:TemplateField HeaderText="Código" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
																		   <asp:Label ID="lblcod_producto" runat="server" Text='<%# Bind("material") %>' ToolTip="Documento de Reclamo del Cliente"></asp:Label>
                          
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

															  <asp:TemplateField HeaderText="Descripción" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
                                                      
																		   <asp:Label ID="lbldesc_material" runat="server" Text='<%# Bind("descripcion_material") %>' ToolTip=""></asp:Label>
                                              
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

                                       
														   <asp:TemplateField HeaderText="Unidad Medida" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
																   <asp:Label ID="lblunidad_medida" runat="server" Text='<%# Bind("unidad_medida") %>'></asp:Label>
															   </ItemTemplate>
                      
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                      
														   </asp:TemplateField>
                                           
		                                   

													   </Columns>

														</asp:GridView>



										</div>
										</div>
											

										
											
								

							<!--end::Row-->
			
								<!--begin::Modal - Select Location-->
								<div class="modal fade" id="kt_modal_select_location" tabindex="-1" aria-hidden="true">
									<!--begin::Modal dialog-->
									<div class="modal-dialog mw-1000px">
										<!--begin::Modal content-->
										<div class="modal-content">
											<!--begin::Modal header-->
											<div class="modal-header">
												<!--begin::Title-->
												<h2>Select Location</h2>
												<!--end::Title-->
												<!--begin::Close-->
												<div class="btn btn-sm btn-icon btn-active-color-primary" data-bs-dismiss="modal">
													<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
													<span class="svg-icon svg-icon-1">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="black" />
															<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="black" />
														</svg>
													</span>
													<!--end::Svg Icon-->
												</div>
												<!--end::Close-->
											</div>
											<!--end::Modal header-->
											<!--begin::Modal body-->
											<div class="modal-body">
												<div id="kt_modal_select_location_map" class="w-100 rounded" style="height:450px"></div>
											</div>
											<!--end::Modal body-->
											<!--begin::Modal footer-->
											<div class="modal-footer d-flex justify-content-end">
												<a href="#" class="btn btn-active-light me-5" data-bs-dismiss="modal">Cancel</a>
												<button type="button" id="kt_modal_select_location_button" class="btn btn-primary" data-bs-dismiss="modal">Apply</button>
											</div>
											<!--end::Modal footer-->
										</div>
										<!--end::Modal content-->
									</div>
									<!--end::Modal dialog-->
								</div>
								<!--end::Modal - Select Location-->
								<!--end::Modals-->
								<!--end::Container-->
								<!--end::Content-->
								<!--end::Main-->
								<!--begin::Footer-->



						
								<br />
								<br />
								<br />
								<br />
								<br />
								<br />
								<div class="footer py-4 d-flex flex-lg-column" id="kt_footer">
									<!--begin::Container-->
									<div class="container-xxl d-flex flex-column flex-md-row flex-stack">
										<!--begin::Copyright-->
										<div class="text-dark order-2 order-md-1">
											<span class="text-muted fw-bold me-2">Desarrollo de Sistemas</span>
											<a href="https://keenthemes.com" target="_blank" class="text-gray-800 text-hover-primary">Área de Tecnología de la Información</a>
										</div>
										<!--end::Copyright-->
										<!--begin::Menu-->
										<%--<ul class="menu menu-gray-600 menu-hover-primary fw-bold order-1">
											<li class="menu-item">
												<a href="https://keenthemes.com" target="_blank" class="menu-link px-2">About</a>
											</li>
											<li class="menu-item">
												<a href="https://keenthemes.com/support" target="_blank" class="menu-link px-2">Support</a>
											</li>
											<li class="menu-item">
												<a href="https://themes.getbootstrap.com/product/start-multipurpose-admin-dashboard-theme/" target="_blank" class="menu-link px-2">Purchase</a>
											</li>
										</ul>--%>
										<!--end::Menu-->
									</div>
									<!--end::Container-->
								</div>
								<!--end::Footer-->
								<!--end::Wrapper-->
								<!--end::Page-->
								<!--end::Root-->
								<!--begin::Header Search-->



								<div class="modal fade" tabindex="-1" id="myModal_busqueda">
											<div class="modal-dialog">
													<div class="modal-content">
													<div class="modal-header">
														<h5 class="modal-title">Inventariar el Producto</h5>
													</div>

													<div class="modal-body">
														<div class="mb-6">
														<label for="exampleFormControlInput1" class="required form-label">Código de Producto</label>
														<asp:Label ID="lblcodigo_producto" runat="server" Text="" class="form-control form-control-solid"></asp:Label>
														</div>
														<div class="mb-6">
														<label for="exampleFormControlInput1" class="required form-label">Descripción del Producto</label>
														<asp:Label ID="lbldesc_producto" runat="server" Text="" class="form-control form-control-solid"></asp:Label>
														</div>
														<div class="mb-6">
														<label for="exampleFormControlInput1" class="form-label">Unidad de Medida Base</label>
														<asp:Label ID="lblunidad_medida" runat="server" Text="" class="form-control form-control-solid"></asp:Label>
														</div>

														<div class="mb-6">
														<label for="exampleFormControlInput1" class="form-label"><asp:Label ID="lblUM" runat="server" Text="Unidades de Medida"></asp:Label></label>
														<asp:DropDownList ID="cbounidades_medida" runat="server" class="form-select form-select-lg form-select-solid" ></asp:DropDownList>
														</div>

														<div class="mb-6">
														<label for="exampleFormControlInput1" class="form-label">Estado Stock</label>
														<asp:DropDownList ID="cboestado_stock" runat="server" class="form-select form-select-lg form-select-solid" ></asp:DropDownList>
														</div>
														<div class="mb-6">
														<label for="exampleFormControlInput1" class="form-label">Ingrese cantidad</label>
															<asp:Panel ID="Panel3" runat="server" DefaultButton="btnRegistrar">														
														      <asp:TextBox ID="txtcantidad" runat="server" class="form-control form-control-solid" placeholder="Ingresar la cantidad encontrada" oninput="limitarDecimales(this, 3)"  OnClientClick="deshabilitarBoton()"></asp:TextBox>


															</asp:Panel>
														</div>
														
<asp:PlaceHolder ID="phFechaVencimiento" runat="server" Visible="false">
	<div class="mb-6">
		<label for="txtfecha_inventario" class="form-label">Fecha de Vencimiento</label>
		<asp:TextBox ID="txtfecha_vencimiento" runat="server" CssClass="form-control form-control-solid" TextMode="Date"></asp:TextBox>
	</div>
</asp:PlaceHolder>



													
														<div class="mb-6">
															<asp:LinkButton ID="btnRegistrar" runat="server" class="btn btn-bg-light" OnClientClick="mostrarLoadingModal();">Registrar</asp:LinkButton>
														</div>

<!-- Capa de bloqueo dentro del modal de búsqueda -->
                <div id="bloqueoModalBusqueda" style="display:none; position:absolute; top:0; left:0; width:100%; height:100%; background-color:rgba(255,255,255,0.7); z-index:1050;"></div>

													</div>

													<div class="modal-footer">

													</div>
												</div>
												</div>

									<script type="text/javascript">
                                        $('#myModal_busqueda').on('shown.bs.modal', function () {
                                            $('#<%=txtcantidad.ClientID%>').focus();
											});
                                    </script>


									<script type="text/javascript">
                                        function limitarDecimales(input, maxDecimales) {
                                            // Obtiene el valor actual del campo
                                            var valor = input.value;

                                            // Encuentra la posición del punto decimal
                                            var puntoIndex = valor.indexOf('.');

                                            // Si el punto decimal existe y la longitud de la parte decimal es mayor que 'maxDecimales'
                                            if (puntoIndex !== -1 && valor.substring(puntoIndex + 1).length > maxDecimales) {
                                                // Corta la parte decimal para tener solo 'maxDecimales'
                                                input.value = valor.substring(0, puntoIndex + maxDecimales + 1);
                                            }
                                        }
                                    </script>
									<script type="text/javascript">
                                        function deshabilitarBoton() {
                                            // Deshabilita el botón
                                            document.getElementById('<%= btnRegistrar.ClientID %>').disabled = true;
                                        }
                                    </script>






							</div>


<!-- Modal de Cargando -->
<div class="modal fade" id="myModalCargando" tabindex="-1" aria-labelledby="loadingModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
     <div class="modal-dialog d-flex align-items-center justify-content-center" style="min-height: 100vh;">
        <div class="modal-content">
            <div class="modal-body text-center">
                <h5>Estamos procesando tu solicitud...</h5>
                <div class="spinner-border" role="status">
                    <span class="visually-hidden">Cargando...</span>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Capa de bloqueo de pantalla completa -->
<div id="bloqueoPantalla" style="display:none; position:fixed; top:0; left:0; width:100%; height:100%; background-color:rgba(0,0,0,0.5); z-index:1050;"></div>

<script type="text/javascript">
	function mostrarLoadingModal() {
        // Muestra el modal de "Cargando"
		$('#myModalCargando').modal('show');
        //document.getElementById("bloqueoPantalla").style.display = "block";
		document.getElementById('<%= btnRegistrar.ClientID %>').disabled = true;
        document.getElementById("bloqueoModalBusqueda").style.display = "block";
    }
</script>



								<div class="modal fade" tabindex="-1" id="myModal_inventariados">
											<div class="modal-dialog">
													<div class="modal-content">
													<div class="modal-header">
														<h5 class="modal-title">Productos Inventariados</h5>
													</div>

													<div class="modal-body">
													
													

													</div>

													<div class="modal-footer">
													<%--	<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
														<asp:Button ID="btnprocesar" runat="server" Text="Procesar" class="btn btn-light"/>--%>
											<%--			<asp:LinkButton ID="btncerrar1" runat="server" class="btn btn-light" data-bs-dismiss="modal fade">LinkButton</asp:LinkButton>
														<button type="button" class="btn btn-primary">Save changes</button>--%>
											
													</div>
												</div>
												</div>
							</div>

								<div id="myModal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" style="display: none;">
                                    <div class="modal-dialog modal-xl">
                                        <div class="modal-content">
                                            <div class="modal-header" style="background-color: #FFFFFF; color: #860264;">
                                                <h2 class="modal-title" id="myLargeModalLabel">
                                                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                        <ContentTemplate>
                                                         <asp:Label ID="lbltituloCasos" runat="server" Text="Listado de Productos Inventariados" ForeColor="#1689CA"></asp:Label>
                                                     </ContentTemplate></asp:UpdatePanel>
                                                  </h2>
                                                
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                            </div>
                                            <div class="modal-body">
                
														<div class="mb-6">
														<label for="exampleFormControlInput1" class="required form-label">Seleccione Almacén (Zona):</label>
														<asp:DropDownList ID="cbozona2" runat="server" class="form-select form-select-lg form-select-solid" AutoPostBack="True"></asp:DropDownList>
														</div>
																											
														<div class="mb-6" style="overflow: auto">

															<asp:GridView ID="grvinventariados" runat="server" class="table product-overview" AutoGenerateColumns="False" AllowSorting="True">
															  <Columns>
                                       
																   <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60">
															   <ItemTemplate>
																 
																		 <%--  <asp:LinkButton ID="btnEliminar" runat="server" class="btn waves-effect waves-light btn-rounded btn-light" CommandName="eliminar" CommandArgument='<%# Bind("id_det_invent") %>'>
																			   Eliminar</asp:LinkButton>--%>
																			<table>
																				<tr>
																					<td>
																						<asp:Label ID="lblid_det_invent" runat="server" Text='<%# Bind("id_det_invent") %>' Visible="False"></asp:Label>
																						<asp:LinkButton ID="btnEliminar" runat="server"  class="btn btn-sm btn-icon btn-active-light-primary me-1" CommandName="eliminar" CommandArgument='<%# Bind("id_det_invent") %>' data-bs-toggle="tooltip" title="Eliminar registro">
																						 <i class="bi bi-trash fs-3"></i></asp:LinkButton>

																					</td>
																					<td>
																						<asp:LinkButton ID="btnmodificar" runat="server"  class="btn btn-sm btn-icon btn-active-light-primary me-1" CommandName="modificar" CommandArgument='<%# Bind("id_det_invent") %>' data-bs-toggle="tooltip" title="Modificar registro">
																						<i class="bi bi-pencil fs-3"></i></asp:LinkButton>

																					</td>
																				</tr>
																			</table>
																			
																			

																		<%--<button class="btn btn-sm btn-icon btn-active-light-primary me-1" type="button" data-bs-toggle="tooltip" title="Coming soon">
																			<i class="bi bi-paperclip fs-3"></i>
																		</button>--%>
                                               
															   </ItemTemplate>
                    
																	   <HeaderStyle BackColor="" ForeColor="Black" />
																	   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>
														  <asp:TemplateField HeaderText="Cantidad Registrada" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
                                                      
																		<%--   <asp:Label ID="lblcan_producto_inv" runat="server" Text='<%# Bind("cant_prod_det_invent") %>' ToolTip=""></asp:Label>--%>

																			 <asp:TextBox ID="txtcan_producto_inv" runat="server" Text='<%# Bind("cant_prod_det_invent") %>'  class="form-control form-control-solid" onkeypress="return NumCheck(event, this)"></asp:TextBox>
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

															<asp:TemplateField HeaderText="Estado Stock" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
																   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
																	   <ContentTemplate>
																		   <asp:DropDownList ID="cboestado_stock_inv" runat="server" class="form-select form-select-lg form-select-solid" >
																			  <asp:ListItem Value ="1" Selected="True">Libre Disponibilidad</asp:ListItem>
																			   <asp:ListItem Value ="2">Bloqueado</asp:ListItem>
																			   <asp:ListItem Value ="3">Calidad</asp:ListItem>
																		   </asp:DropDownList>
																	   </ContentTemplate>
																   </asp:UpdatePanel>
																	
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>


														   <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
																		   <asp:Label ID="lblfecha_registro" runat="server" Text='<%# Bind("fec_creac_det_invent") %>'></asp:Label>
                          
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

														<asp:TemplateField HeaderText="Cod. Producto" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
                                                      
																		   <asp:Label ID="lblcod_producto_inv" runat="server" Text='<%# Bind("cod_prod_sap") %>' ToolTip=""></asp:Label>
                                              
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

															  <asp:TemplateField HeaderText="Descripción" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
                                                      
																		   <asp:Label ID="lbldesc_producto_inv" runat="server" Text='<%# Bind("desc_prod_det_invent") %>' ToolTip=""></asp:Label>
                                              
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

                                                            
																  
															<asp:TemplateField HeaderText="Registrado por" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-BackColor="" HeaderStyle-ForeColor="Black" >
															   <ItemTemplate>
                                                      
																		   <asp:Label ID="lblusuario_reg" runat="server" Text='<%# Bind("nombre_usuario_creac") %>' ToolTip=""></asp:Label>
                                              
															   </ItemTemplate>
                    
															   <HeaderStyle BackColor="" ForeColor="Black" />
															   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
														   </asp:TemplateField>

		                                   

													   </Columns>

														</asp:GridView>



														</div>




                                            </div>
                                            <div class="modal-footer">
                                                <%--<button type="button" class="btn btn-danger waves-effect text-left" data-dismiss="modal">Cerrar</button>--%>
                                            </div>
                                        </div>
                                        <!-- /.modal-content -->
                                    </div>
                                    <!-- /.modal-dialog -->
                                </div>

								<div class="modal fade" tabindex="-1" id="myModal_Mensaje">
											<div class="modal-dialog">
													<div class="modal-content">
													<div class="modal-header">
														<h5 class="modal-title">Sistema de Inventario												<!--begin::Close-->
														<div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close">
															<span class="svg-icon svg-icon-2x"></span>
														</div>
														<!--end::Close-->
													</div>

													<div class="modal-body">
														<p>
															<asp:UpdatePanel ID="UpdatePanel5" runat="server">
																<ContentTemplate>
																	<asp:Label ID="lblmensaje" runat="server" Text="Label"></asp:Label>
																	<br />
																	<br />
																	<asp:Label ID="lblmensajealerta" runat="server" Text="Label"></asp:Label>
																</ContentTemplate>
															</asp:UpdatePanel>
														</p>
													</div>

													<div class="modal-footer">
													<%--	<button type="button" class="btn btn-light" data-bs-dismiss="modal">Close</button>
														<asp:Button ID="btnprocesar" runat="server" Text="Procesar" class="btn btn-light"/>--%>
											<%--			<asp:LinkButton ID="btncerrar1" runat="server" class="btn btn-light" data-bs-dismiss="modal fade">LinkButton</asp:LinkButton>
														<button type="button" class="btn btn-primary">Save changes</button>--%>
										       	<asp:Button ID="btncerra_modificar" runat="server" Text="Cerrar" class="btn btn-light"/>
													</div>
												</div>
												</div>
										</div>


								<div class="modal bg-white fade" id="kt_header_search_modal" aria-hidden="true">
									<div class="modal-dialog modal-fullscreen">
										<div class="modal-content shadow-none">
											<div class="container w-lg-800px">
												<div class="modal-header d-flex justify-content-end border-0">
													<!--begin::Close-->
													<div class="btn btn-icon btn-sm btn-light-primary ms-2" data-bs-dismiss="modal">
														<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
														<span class="svg-icon svg-icon-1">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="black" />
																<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="black" />
															</svg>
														</span>
														<!--end::Svg Icon-->
													</div>
													<!--end::Close-->
												</div>
												<div class="modal-body">
													<!--begin::Search-->
													<form class="pb-10">
														<input autofocus="" type="text" class="form-control bg-transparent border-0 fs-4x text-center fw-normal" name="query" placeholder="Search..." />
													</form>
													<!--end::Search-->
													<!--begin::Shop Goods-->
													<div class="py-10">
														<h3 class="fw-bolder mb-8">Shop Goods</h3>
														<!--begin::Row-->
														<div class="row g-5">
															<div class="col-sm-6">
																<div class="row g-5">
																	<div class="col-sm-6">
																		<div class="card overlay min-h-125px mb-5 shadow-none">
																			<div class="card-body d-flex flex-column p-0">
																				<div class="overlay-wrapper flex-grow-1 bgi-no-repeat bgi-size-cover bgi-position-center card-rounded" style="background-image:url('assets/media/stock/600x400/img-17.jpg')"></div>
																				<div class="overlay-layer bg-white bg-opacity-50">
																					<a href="#" class="btn btn-sm fw-bold btn-primary">Explore</a>
																				</div>
																			</div>
																		</div>
																		<div class="card overlay min-h-125px mb-5 shadow-none">
																			<div class="card-body d-flex flex-column p-0">
																				<div class="overlay-wrapper flex-grow-1 bgi-no-repeat bgi-size-cover bgi-position-center card-rounded" style="background-image:url('assets/media/stock/600x400/img-1.jpg')"></div>
																				<div class="overlay-layer bg-white bg-opacity-50">
																					<a href="#" class="btn btn-sm fw-bold btn-primary">Explore</a>
																				</div>
																			</div>
																		</div>
																	</div>
																	<div class="col-sm-6">
																		<div class="card card-stretch overlay mb-5 shadow-none min-h-250px">
																			<div class="card-body d-flex flex-column p-0">
																				<div class="overlay-wrapper flex-grow-1 bgi-no-repeat bgi-size-cover bgi-position-center card-rounded" style="background-image:url('assets/media/stock/600x400/img-23.jpg')"></div>
																				<div class="overlay-layer bg-white bg-opacity-50">
																					<a href="#" class="btn btn-sm fw-bold btn-primary">Explore</a>
																				</div>
																			</div>
																		</div>
																	</div>
																</div>
															</div>
															<div class="col-sm-6">
																<div class="card card-stretch overlay mb-5 shadow-none min-h-250px">
																	<div class="card-body d-flex flex-column p-0">
																		<div class="overlay-wrapper flex-grow-1 bgi-no-repeat bgi-size-cover bgi-position-center card-rounded" style="background-image:url('assets/media/stock/600x400/img-11.jpg')"></div>
																		<div class="overlay-layer bg-white bg-opacity-50">
																			<a href="#" class="btn btn-sm fw-bold btn-primary">Explore</a>
																		</div>
																	</div>
																</div>
															</div>
														</div>
														<!--end::Row-->
													</div>
													<!--end::Shop Goods-->
													<!--begin::Framework Users-->
													<div>
														<h3 class="text-dark fw-bolder fs-1 mb-6">Framework Users</h3>
														<!--begin::List Widget 4-->
														<div class="card bg-transparent mb-5 shadow-none">
															<!--begin::Body-->
															<div class="card-body pt-2 px-0">
																<div class="table-responsive">
																	<table class="table table-borderless align-middle">
																		<!--begin::Item-->
																		<tr>
																			<th class="ps-0 w-55px">
																				<!--begin::Symbol-->
																				<div class="symbol symbol-55px flex-shrink-0 me-4">
																					<span class="symbol-label bg-light-primary">
																						<img src="assets/media/svg/avatars/009-boy-4.svg" class="h-75 align-self-end" alt="" />
																					</span>
																				</div>
																				<!--end::Symbol-->
																			</th>
																			<td class="ps-0 flex-column min-w-300px">
																				<!--begin::Title-->
																				<a href="#" class="text-gray-800 fw-bolder text-hover-primary fs-6 mb-1">Brad Simmons</a>
																				<div class="text-muted fw-bold">Uses: HTML/CSS/JS, Python</div>
																				<!--end::Title-->
																			</td>
																			<td>
																				<!--begin::Label-->
																				<div class="me-4 me-md-19 text-md-right">
																					<div class="text-gray-800 fw-bolder fs-6 mb-1">$2,000,000</div>
																					<span class="text-muted fw-bold">Paid</span>
																				</div>
																				<!--end::Label-->
																			</td>
																			<td class="text-end pe-0">
																				<!--begin::Btn-->
																				<a href="#" class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm">
																					<!--begin::Svg Icon | path: icons/duotune/arrows/arr064.svg-->
																					<span class="svg-icon svg-icon-4">
																						<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																							<rect opacity="0.5" x="18" y="13" width="13" height="2" rx="1" transform="rotate(-180 18 13)" fill="black" />
																							<path d="M15.4343 12.5657L11.25 16.75C10.8358 17.1642 10.8358 17.8358 11.25 18.25C11.6642 18.6642 12.3358 18.6642 12.75 18.25L18.2929 12.7071C18.6834 12.3166 18.6834 11.6834 18.2929 11.2929L12.75 5.75C12.3358 5.33579 11.6642 5.33579 11.25 5.75C10.8358 6.16421 10.8358 6.83579 11.25 7.25L15.4343 11.4343C15.7467 11.7467 15.7467 12.2533 15.4343 12.5657Z" fill="black" />
																						</svg>
																					</span>
																					<!--end::Svg Icon-->
																				</a>
																				<!--end::Btn-->
																			</td>
																		</tr>
																		<!--end::Item-->
																		<!--begin::Item-->
																		<tr>
																			<th class="ps-0">
																				<!--begin::Symbol-->
																				<div class="symbol symbol-55px flex-shrink-0 me-4">
																					<span class="symbol-label bg-light-danger">
																						<img src="assets/media/svg/avatars/006-girl-3.svg" class="h-75 align-self-end" alt="" />
																					</span>
																				</div>
																				<!--end::Symbol-->
																			</th>
																			<td class="ps-0 flex-column min-w-300px">
																				<!--begin::Title-->
																				<a href="#" class="text-gray-800 fw-bolder text-hover-primary fs-6 mb-1">Jessie Clarcson</a>
																				<div class="text-muted fw-bold">Uses: HTML, ReactJS, ASP.NET</div>
																				<!--end::Title-->
																			</td>
																			<td>
																				<!--end::Label-->
																				<div class="me-4 me-md-19 text-md-right">
																					<div class="text-gray-800 fw-bolder fs-6 mb-1">$1,200,000</div>
																					<span class="text-muted fw-bold">Paid</span>
																				</div>
																				<!--end::Label-->
																			</td>
																			<td class="text-end pe-0">
																				<!--begin::Btn-->
																				<a href="#" class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm">
																					<!--begin::Svg Icon | path: icons/duotune/arrows/arr064.svg-->
																					<span class="svg-icon svg-icon-4">
																						<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																							<rect opacity="0.5" x="18" y="13" width="13" height="2" rx="1" transform="rotate(-180 18 13)" fill="black" />
																							<path d="M15.4343 12.5657L11.25 16.75C10.8358 17.1642 10.8358 17.8358 11.25 18.25C11.6642 18.6642 12.3358 18.6642 12.75 18.25L18.2929 12.7071C18.6834 12.3166 18.6834 11.6834 18.2929 11.2929L12.75 5.75C12.3358 5.33579 11.6642 5.33579 11.25 5.75C10.8358 6.16421 10.8358 6.83579 11.25 7.25L15.4343 11.4343C15.7467 11.7467 15.7467 12.2533 15.4343 12.5657Z" fill="black" />
																						</svg>
																					</span>
																					<!--end::Svg Icon-->
																				</a>
																				<!--end::Btn-->
																			</td>
																		</tr>
																		<!--end::Item-->
																		<!--begin::Item-->
																		<tr>
																			<th class="ps-0">
																				<!--begin::Symbol-->
																				<div class="symbol symbol-55px flex-shrink-0 me-4">
																					<span class="symbol-label bg-light-success">
																						<img src="assets/media/svg/avatars/011-boy-5.svg" class="h-75 align-self-end" alt="" />
																					</span>
																				</div>
																				<!--end::Symbol-->
																			</th>
																			<td class="ps-0 flex-column min-w-300px">
																				<!--begin::Title-->
																				<a href="#" class="text-gray-800 fw-bolder text-hover-primary fs-6 mb-1">Lebron Wayde</a>
																				<div class="text-muted fw-bold">Uses: HTML. Laravel Framework</div>
																				<!--end::Title-->
																			</td>
																			<td>
																				<!--end::Label-->
																				<div class="me-4 me-md-19 text-md-right">
																					<div class="text-gray-800 fw-bolder fs-6 mb-1">$3,400,000</div>
																					<span class="text-muted fw-bold">Paid</span>
																				</div>
																				<!--end::Label-->
																			</td>
																			<td class="text-end pe-0">
																				<!--begin::Btn-->
																				<a href="#" class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm">
																					<!--begin::Svg Icon | path: icons/duotune/arrows/arr064.svg-->
																					<span class="svg-icon svg-icon-4">
																						<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																							<rect opacity="0.5" x="18" y="13" width="13" height="2" rx="1" transform="rotate(-180 18 13)" fill="black" />
																							<path d="M15.4343 12.5657L11.25 16.75C10.8358 17.1642 10.8358 17.8358 11.25 18.25C11.6642 18.6642 12.3358 18.6642 12.75 18.25L18.2929 12.7071C18.6834 12.3166 18.6834 11.6834 18.2929 11.2929L12.75 5.75C12.3358 5.33579 11.6642 5.33579 11.25 5.75C10.8358 6.16421 10.8358 6.83579 11.25 7.25L15.4343 11.4343C15.7467 11.7467 15.7467 12.2533 15.4343 12.5657Z" fill="black" />
																						</svg>
																					</span>
																					<!--end::Svg Icon-->
																				</a>
																				<!--end::Btn-->
																			</td>
																		</tr>
																		<!--end::Item-->
																		<!--begin::Item-->
																		<tr>
																			<th class="ps-0">
																				<!--begin::Symbol-->
																				<div class="symbol symbol-55px flex-shrink-0 me-4">
																					<span class="symbol-label bg-light-warning">
																						<img src="assets/media/svg/avatars/015-boy-6.svg" class="h-75 align-self-end" alt="" />
																					</span>
																				</div>
																				<!--end::Symbol-->
																			</th>
																			<td class="ps-0 flex-column min-w-300px">
																				<!--begin::Title-->
																				<a href="#" class="text-gray-800 fw-bolder text-hover-primary fs-6 mb-1">Kevin Leonard</a>
																				<div class="text-muted fw-bold">Uses: VueJS, Laravel Framework</div>
																				<!--end::Title-->
																			</td>
																			<td>
																				<!--end::Label-->
																				<div class="me-4 me-md-19 text-md-right">
																					<div class="text-gray-800 fw-bolder fs-6 mb-1">$35,600,000</div>
																					<span class="text-muted fw-bold">Paid</span>
																				</div>
																				<!--end::Label-->
																			</td>
																			<td class="text-end pe-0">
																				<!--begin::Btn-->
																				<a href="#" class="btn btn-icon btn-bg-light btn-active-color-primary btn-sm">
																					<!--begin::Svg Icon | path: icons/duotune/arrows/arr064.svg-->
																					<span class="svg-icon svg-icon-4">
																						<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																							<rect opacity="0.5" x="18" y="13" width="13" height="2" rx="1" transform="rotate(-180 18 13)" fill="black" />
																							<path d="M15.4343 12.5657L11.25 16.75C10.8358 17.1642 10.8358 17.8358 11.25 18.25C11.6642 18.6642 12.3358 18.6642 12.75 18.25L18.2929 12.7071C18.6834 12.3166 18.6834 11.6834 18.2929 11.2929L12.75 5.75C12.3358 5.33579 11.6642 5.33579 11.25 5.75C10.8358 6.16421 10.8358 6.83579 11.25 7.25L15.4343 11.4343C15.7467 11.7467 15.7467 12.2533 15.4343 12.5657Z" fill="black" />
																						</svg>
																					</span>
																					<!--end::Svg Icon-->
																				</a>
																				<!--end::Btn-->
																			</td>
																		</tr>
																		<!--end::Item-->
																	</table>
																</div>
															</div>
															<!--end::Body-->
														</div>
														<!--end::List Widget 4-->
													</div>
													<!--end::Framework Users-->
													<!--begin::Tutorials-->
													<div class="pb-10">
														<h3 class="text-dark fw-bolder fs-1 mb-6">Tutorials</h3>
														<!--begin::List Widget 5-->
														<div class="card mb-5 shadow-none">
															<!--begin::Body-->
															<div class="card-body pt-2 px-0">
																<!--begin::Item-->
																<div class="d-flex mb-6">
																	<!--begin::Icon-->
																	<div class="me-1">
																		<!--begin::Svg Icon | path: icons/duotune/arrows/arr071.svg-->
																		<span class="svg-icon svg-icon-sm svg-icon-primary">
																			<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																				<path d="M12.6343 12.5657L8.45001 16.75C8.0358 17.1642 8.0358 17.8358 8.45001 18.25C8.86423 18.6642 9.5358 18.6642 9.95001 18.25L15.4929 12.7071C15.8834 12.3166 15.8834 11.6834 15.4929 11.2929L9.95001 5.75C9.5358 5.33579 8.86423 5.33579 8.45001 5.75C8.0358 6.16421 8.0358 6.83579 8.45001 7.25L12.6343 11.4343C12.9467 11.7467 12.9467 12.2533 12.6343 12.5657Z" fill="black" />
																			</svg>
																		</span>
																		<!--end::Svg Icon-->
																	</div>
																	<!--end::Icon-->
																	<!--begin::Content-->
																	<div class="d-flex flex-column">
																		<a href="#" class="fs-6 fw-bolder text-hover-primary text-gray-800 mb-2">How to Create Your First Project with Start Admin Theme</a>
																		<div class="fw-bold text-muted">But nothing can prepare you for the real thing</div>
																	</div>
																	<!--end::Content-->
																</div>
																<!--end::Item-->
																<!--begin::Item-->
																<div class="d-flex mb-6">
																	<!--begin::Icon-->
																	<div class="me-1">
																		<!--begin::Svg Icon | path: icons/duotune/arrows/arr071.svg-->
																		<span class="svg-icon svg-icon-sm svg-icon-primary">
																			<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																				<path d="M12.6343 12.5657L8.45001 16.75C8.0358 17.1642 8.0358 17.8358 8.45001 18.25C8.86423 18.6642 9.5358 18.6642 9.95001 18.25L15.4929 12.7071C15.8834 12.3166 15.8834 11.6834 15.4929 11.2929L9.95001 5.75C9.5358 5.33579 8.86423 5.33579 8.45001 5.75C8.0358 6.16421 8.0358 6.83579 8.45001 7.25L12.6343 11.4343C12.9467 11.7467 12.9467 12.2533 12.6343 12.5657Z" fill="black" />
																			</svg>
																		</span>
																		<!--end::Svg Icon-->
																	</div>
																	<!--end::Icon-->
																	<!--begin::Content-->
																	<div class="d-flex flex-column">
																		<a href="#" class="fs-6 fw-bolder text-hover-primary text-gray-800 mb-2">Start Admin Theme Getting Started &amp; Installation</a>
																		<div class="fw-bold text-muted">Long before you sit down to put digital pen</div>
																	</div>
																	<!--end::Content-->
																</div>
																<!--end::Item-->
																<!--begin::Item-->
																<div class="d-flex mb-6">
																	<!--begin::Icon-->
																	<div class="me-1">
																		<!--begin::Svg Icon | path: icons/duotune/arrows/arr071.svg-->
																		<span class="svg-icon svg-icon-sm svg-icon-primary">
																			<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																				<path d="M12.6343 12.5657L8.45001 16.75C8.0358 17.1642 8.0358 17.8358 8.45001 18.25C8.86423 18.6642 9.5358 18.6642 9.95001 18.25L15.4929 12.7071C15.8834 12.3166 15.8834 11.6834 15.4929 11.2929L9.95001 5.75C9.5358 5.33579 8.86423 5.33579 8.45001 5.75C8.0358 6.16421 8.0358 6.83579 8.45001 7.25L12.6343 11.4343C12.9467 11.7467 12.9467 12.2533 12.6343 12.5657Z" fill="black" />
																			</svg>
																		</span>
																		<!--end::Svg Icon-->
																	</div>
																	<!--end::Icon-->
																	<!--begin::Content-->
																	<div class="d-flex flex-column">
																		<a href="#" class="fs-6 fw-bolder text-hover-primary text-gray-800 mb-2">Craft a headline that is both informative and will capture</a>
																		<div class="fw-bold text-muted">But nothing can prepare you for the real thing</div>
																	</div>
																	<!--end::Content-->
																</div>
																<!--end::Item-->
																<!--begin::Item-->
																<div class="d-flex mb-6">
																	<!--begin::Icon-->
																	<div class="me-1">
																		<!--begin::Svg Icon | path: icons/duotune/arrows/arr071.svg-->
																		<span class="svg-icon svg-icon-sm svg-icon-primary">
																			<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																				<path d="M12.6343 12.5657L8.45001 16.75C8.0358 17.1642 8.0358 17.8358 8.45001 18.25C8.86423 18.6642 9.5358 18.6642 9.95001 18.25L15.4929 12.7071C15.8834 12.3166 15.8834 11.6834 15.4929 11.2929L9.95001 5.75C9.5358 5.33579 8.86423 5.33579 8.45001 5.75C8.0358 6.16421 8.0358 6.83579 8.45001 7.25L12.6343 11.4343C12.9467 11.7467 12.9467 12.2533 12.6343 12.5657Z" fill="black" />
																			</svg>
																		</span>
																		<!--end::Svg Icon-->
																	</div>
																	<!--end::Icon-->
																	<!--begin::Content-->
																	<div class="d-flex flex-column">
																		<a href="#" class="fs-6 fw-bolder text-hover-primary text-gray-800 mb-2">Write your post, either writing a draft in a single</a>
																		<div class="fw-bold text-muted">Long before you sit down to put pen</div>
																	</div>
																	<!--end::Content-->
																</div>
																<!--end::Item-->
																<!--begin::Item-->
																<div class="d-flex mb-6">
																	<!--begin::Icon-->
																	<div class="me-1">
																		<!--begin::Svg Icon | path: icons/duotune/arrows/arr071.svg-->
																		<span class="svg-icon svg-icon-sm svg-icon-primary">
																			<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																				<path d="M12.6343 12.5657L8.45001 16.75C8.0358 17.1642 8.0358 17.8358 8.45001 18.25C8.86423 18.6642 9.5358 18.6642 9.95001 18.25L15.4929 12.7071C15.8834 12.3166 15.8834 11.6834 15.4929 11.2929L9.95001 5.75C9.5358 5.33579 8.86423 5.33579 8.45001 5.75C8.0358 6.16421 8.0358 6.83579 8.45001 7.25L12.6343 11.4343C12.9467 11.7467 12.9467 12.2533 12.6343 12.5657Z" fill="black" />
																			</svg>
																		</span>
																		<!--end::Svg Icon-->
																	</div>
																	<!--end::Icon-->
																	<!--begin::Content-->
																	<div class="d-flex flex-column">
																		<a href="#" class="fs-6 fw-bolder text-hover-primary text-gray-800 mb-2">Use images to enhance your post, improve its flow</a>
																		<div class="fw-bold text-muted">Long before you sit down to put digital pen</div>
																	</div>
																	<!--end::Content-->
																</div>
																<!--end::Item-->
															</div>
															<!--end::Body-->
														</div>
														<!--end::List Widget 5-->
													</div>
													<!--end::Tutorials-->
												</div>
											</div>
										</div>
									</div>
								</div>
								<!--end::Header Search-->
								<!--begin::Mega Menu-->
								<div class="modal bg-white fade" id="kt_mega_menu_modal" tabindex="-1" aria-hidden="true">
									<div class="modal-dialog modal-fullscreen">
										<div class="modal-content shadow-none" style="background-color: #FF00FF">
											<div class="container" >
												<div class="modal-header d-flex flex-stack border-0" >
													<div class="d-flex align-items-center">
														<!--begin::Logo-->
														<a href="../dist/index.html">
															<img alt="Logo" src="assets/media/logos/logo-default.svg" class="h-30px" />
														</a>
														<!--end::Logo-->
													</div>
													<!--begin::Close-->
													<div class="btn btn-icon btn-sm btn-light-primary ms-2" data-bs-dismiss="modal">
														<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
														<span class="svg-icon svg-icon-1">
															<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
																<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="black" />
																<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="black" />
															</svg>
														</span>
														<!--end::Svg Icon-->
													</div>
													<!--end::Close-->
												</div>
												<div class="modal-body">
													<!--begin::Row-->
													<div class="row py-10 g-5">
														<!--begin::Column-->
														<div class="col-lg-6 pe-lg-25">
															<!--begin::Row-->
															<div class="row">
																<div class="col-sm-4">
																	<h3 class="fw-bolder mb-5">Menú Principal</h3>
																	<ul class="menu menu-column menu-fit menu-rounded menu-gray-600 menu-hover-primary menu-active-primary fw-bold fs-6 mb-10">
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/index.html">Principal</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2 active" href="../dist/dashboards/extended.html">Extended</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/dashboards/light.html">Light</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/dashboards/compact.html">Compact</a>
																		</li>
																	</ul>
																</div>
																<div class="col-sm-4">
																	<h3 class="fw-bolder mb-5">Apps</h3>
																	<ul class="menu menu-column menu-fit menu-rounded menu-gray-600 menu-hover-primary menu-active-primary fw-bold fs-6 mb-10">
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/calendar.html">Calendar</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/chat/private.html">Private Chat</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/chat/group.html">Group Chat</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/chat/drawer.html">Drawer Chat</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/inbox.html">Inbox</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/shop/shop-1.html">Shop 1</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/shop/shop-2.html">Shop 2</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/apps/shop/product.html">Shop Product</a>
																		</li>
																	</ul>
																</div>
																<div class="col-sm-4">
																	<h3 class="fw-bolder mb-5">General</h3>
																	<ul class="menu menu-column menu-fit menu-rounded menu-gray-600 menu-hover-primary menu-active-primary fw-bold fs-6 mb-10">
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/general/faq.html">FAQ</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/general/pricing.html">Pricing</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/general/invoice.html">Invoice</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/general/login.html">Login</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/general/wizard.html">Wizard</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/general/error.html">Error</a>
																		</li>
																	</ul>
																</div>
															</div>
															<!--end::Row-->
															<!--begin::Row-->
															<div class="row">
																<div class="col-sm-4">
																	<h3 class="fw-bolder mb-5">Profile</h3>
																	<ul class="menu menu-column menu-fit menu-rounded menu-gray-600 menu-hover-primary menu-active-primary fw-bold fs-6 mb-10">
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/profile/overview.html">Overview</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/profile/account.html">Account</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/profile/settings.html">Settings</a>
																		</li>
																	</ul>
																</div>
																<div class="col-sm-4">
																	<h3 class="fw-bolder mb-5">Resources</h3>
																	<ul class="menu menu-column menu-fit menu-rounded menu-gray-600 menu-hover-primary menu-active-primary fw-bold fs-6 mb-10">
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/documentation/base/utilities.html">Components</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/documentation/getting-started.html">Documentation</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="https://preview.keenthemes.com/start/layout-builder.html">Layout Builder</a>
																		</li>
																		<li class="menu-item">
																			<a class="menu-link ps-0 py-2" href="../dist/documentation/getting-started/changelog.html">Changelog
																			<span class="badge badge-changelog badge-light-danger bg-hover-danger text-hover-white fw-bold fs-9 px-2 ms-2">v1.0.9</span></a>
																		</li>
																	</ul>
																</div>
															</div>
															<!--end::Row-->
														</div>
														<!--end::Column-->
														<!--begin::Column-->
														<div class="col-lg-6">
															<h3 class="fw-bolder mb-8">Quick Links</h3>
															<!--begin::Row-->
															<div class="row g-5">
																<div class="col-sm-4">
																	<a href="#" class="card bg-light-success hoverable min-h-125px shadow-none mb-5">
																		<div class="card-body d-flex flex-column flex-center">
																			<h3 class="fs-3 mb-2 text-dark fw-bolder">Security</h3>
																			<p class="mb-0 text-gray-600">$2.99/month</p>
																		</div>
																	</a>
																</div>
																<div class="col-sm-4">
																	<a href="#" class="card bg-light-danger hoverable min-h-125px shadow-none mb-5">
																		<div class="card-body d-flex flex-column flex-center text-center">
																			<h3 class="fs-3 mb-2 text-dark fw-bolder">Demo</h3>
																			<p class="mb-0 text-gray-600">Free Version</p>
																		</div>
																	</a>
																</div>
																<div class="col-sm-4">
																	<a href="#" class="card bg-light-warning hoverable min-h-125px shadow-none mb-5">
																		<div class="card-body d-flex flex-column flex-center text-center">
																			<h3 class="fs-3 mb-2 text-dark text-hover-primary fw-bolder">Try Now</h3>
																			<p class="mb-0 text-gray-600">Pro Version</p>
																		</div>
																	</a>
																</div>
															</div>
															<!--end::Row-->
															<!--begin::Row-->
															<div class="row g-5">
																<div class="col-sm-8">
																	<a href="#" class="card bg-light-primary hoverable min-h-125px shadow-none mb-5">
																		<div class="card-body d-flex flex-column flex-center text-center">
																			<h3 class="fs-3 mb-2 text-dark fw-bolder">Payment Methods</h3>
																			<p class="mb-0 text-gray-600">Credit Cards/Debit Cards, Paypal,
																			<br />Transferwise &amp; Others</p>
																		</div>
																	</a>
																	<!--begin::Row-->
																	<div class="row g-5">
																		<div class="col-sm-6">
																			<a class="card bg-light-warning hoverable shadow-none min-h-125px mb-5">
																				<div class="card-body d-flex flex-column flex-center text-center">
																					<h3 class="fs-3 mb-2 text-dark fw-bolder">Support</h3>
																					<p class="mb-0 text-gray-600">6 Month Free</p>
																				</div>
																			</a>
																		</div>
																		<div class="col-sm-6">
																			<a href="#" class="card bg-light-success hoverable shadow-none min-h-125px mb-5">
																				<div class="card-body d-flex flex-column flex-center text-center">
																					<h3 class="fs-3 mb-2 text-dark fw-bolder">Installation</h3>
																					<p class="mb-0 text-gray-600">$0.99 Per Machine</p>
																				</div>
																			</a>
																		</div>
																	</div>
																	<!--end::Row-->
																</div>
																<div class="col-sm-4">
																	<a href="#" class="card card-stretch mb-5 bg-light-info hoverable shadow-none min-h-250px">
																		<div class="card-body d-flex flex-column p-0">
																			<div class="d-flex flex-column flex-grow-1 flex-center text-center px-5 pt-10">
																				<h3 class="fs-3 mb-2 text-dark fw-bolder">Quick Start</h3>
																				<p class="mb-0 text-gray-600">Single Click Import</p>
																			</div>
																			<div class="min-h-125px bgi-no-repeat bgi-size-contain bgi-position-x-center bgi-position-y-bottom card-rounded-bottom" style="background-image:url('assets/media/illustrations/sigma-1/2.png')"></div>
																		</div>
																	</a>
																</div>
															</div>
															<!--end::Row-->
														</div>
														<!--end::Column-->
													</div>
													<!--end::Row-->
												</div>
											</div>
										</div>
									</div>
								</div>
								<!--end::Mega Menu-->
								<!--begin::Drawers-->
								<!--begin::Chat drawer-->
								<div id="kt_drawer_chat" class="bg-body" data-kt-drawer="true" data-kt-drawer-name="chat" data-kt-drawer-activate="true" data-kt-drawer-overlay="true" data-kt-drawer-width="{default:'300px', 'md': '500px'}" data-kt-drawer-direction="end" data-kt-drawer-toggle="#kt_drawer_chat_toggle" data-kt-drawer-close="#kt_drawer_chat_close">
									<!--begin::Messenger-->
									<div class="card w-100 rounded-0" id="kt_drawer_chat_messenger">
										<!--begin::Card header-->
										<div class="card-header pe-5" id="kt_drawer_chat_messenger_header">
											<!--begin::Title-->
											<div class="card-title">
												<!--begin::User-->
												<div class="d-flex justify-content-center flex-column me-3">
													<a href="#" class="fs-4 fw-bolder text-gray-900 text-hover-primary me-1 mb-2 lh-1">Brian Cox</a>
													<!--begin::Info-->
													<div class="mb-0 lh-1">
														<span class="badge badge-success badge-circle w-10px h-10px me-1"></span>
														<span class="fs-7 fw-bold text-muted">Active</span>
													</div>
													<!--end::Info-->
												</div>
												<!--end::User-->
											</div>
											<!--end::Title-->
											<!--begin::Card toolbar-->
											<div class="card-toolbar">
												<!--begin::Menu-->
												<div class="me-2">
													<button class="btn btn-sm btn-icon btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
														<i class="bi bi-three-dots fs-3"></i>
													</button>
													<!--begin::Menu 3-->
													<div class="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-800 menu-state-bg-light-primary fw-bold w-200px py-3" data-kt-menu="true">
														<!--begin::Heading-->
														<div class="menu-item px-3">
															<div class="menu-content text-muted pb-2 px-3 fs-7 text-uppercase">Contacts</div>
														</div>
														<!--end::Heading-->
														<!--begin::Menu item-->
														<div class="menu-item px-3">
															<a href="#" class="menu-link px-3" data-bs-toggle="modal" data-bs-target="#kt_modal_users_search">Add Contact</a>
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3">
															<a href="#" class="menu-link flex-stack px-3" data-bs-toggle="modal" data-bs-target="#kt_modal_invite_friends">Invite Contacts
															<i class="fas fa-exclamation-circle ms-2 fs-7" data-bs-toggle="tooltip" title="Specify a contact email to send an invitation"></i></a>
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3" data-kt-menu-trigger="hover" data-kt-menu-placement="right-start" data-kt-menu-flip="left, center, top">
															<a href="#" class="menu-link px-3">
																<span class="menu-title">Groups</span>
																<span class="menu-arrow"></span>
															</a>
															<!--begin::Menu sub-->
															<div class="menu-sub menu-sub-dropdown w-175px py-4">
																<!--begin::Menu item-->
																<div class="menu-item px-3">
																	<a href="#" class="menu-link px-3" data-bs-toggle="tooltip" title="Coming soon">Create Group</a>
																</div>
																<!--end::Menu item-->
																<!--begin::Menu item-->
																<div class="menu-item px-3">
																	<a href="#" class="menu-link px-3" data-bs-toggle="tooltip" title="Coming soon">Invite Members</a>
																</div>
																<!--end::Menu item-->
																<!--begin::Menu item-->
																<div class="menu-item px-3">
																	<a href="#" class="menu-link px-3" data-bs-toggle="tooltip" title="Coming soon">Settings</a>
																</div>
																<!--end::Menu item-->
															</div>
															<!--end::Menu sub-->
														</div>
														<!--end::Menu item-->
														<!--begin::Menu item-->
														<div class="menu-item px-3 my-1">
															<a href="#" class="menu-link px-3" data-bs-toggle="tooltip" title="Coming soon">Settings</a>
														</div>
														<!--end::Menu item-->
													</div>
													<!--end::Menu 3-->
												</div>
												<!--end::Menu-->
												<!--begin::Close-->
												<div class="btn btn-sm btn-icon btn-active-light-primary" id="kt_drawer_chat_close">
													<!--begin::Svg Icon | path: icons/duotune/arrows/arr061.svg-->
													<span class="svg-icon svg-icon-2">
														<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
															<rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="black" />
															<rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="black" />
														</svg>
													</span>
													<!--end::Svg Icon-->
												</div>
												<!--end::Close-->
											</div>
											<!--end::Card toolbar-->
										</div>
										<!--end::Card header-->
										<!--begin::Card body-->
										<div class="card-body" id="kt_drawer_chat_messenger_body">
											<!--begin::Messages-->
											<div class="scroll-y me-n5 pe-5" data-kt-element="messages" data-kt-scroll="true" data-kt-scroll-activate="true" data-kt-scroll-height="auto" data-kt-scroll-dependencies="#kt_drawer_chat_messenger_header, #kt_drawer_chat_messenger_footer" data-kt-scroll-wrappers="#kt_drawer_chat_messenger_body" data-kt-scroll-offset="0px">
												<!--begin::Message(in)-->
												<div class="d-flex justify-content-start mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-start">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-15.jpg" />
															</div>
															<!--end::Avatar-->
															<!--begin::Details-->
															<div class="ms-3">
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary me-1">Brian Cox</a>
																<span class="text-muted fs-7 mb-1">2 mins</span>
															</div>
															<!--end::Details-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-info text-dark fw-bold mw-lg-400px text-start" data-kt-element="message-text">How likely are you to recommend our company to your friends and family ?</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(in)-->
												<!--begin::Message(out)-->
												<div class="d-flex justify-content-end mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-end">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Details-->
															<div class="me-3">
																<span class="text-muted fs-7 mb-1">5 mins</span>
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary ms-1">You</a>
															</div>
															<!--end::Details-->
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-26.jpg" />
															</div>
															<!--end::Avatar-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-primary text-dark fw-bold mw-lg-400px text-end" data-kt-element="message-text">Hey there, we’re just writing to let you know that you’ve been subscribed to a repository on GitHub.</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(out)-->
												<!--begin::Message(in)-->
												<div class="d-flex justify-content-start mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-start">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-15.jpg" />
															</div>
															<!--end::Avatar-->
															<!--begin::Details-->
															<div class="ms-3">
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary me-1">Brian Cox</a>
																<span class="text-muted fs-7 mb-1">1 Hour</span>
															</div>
															<!--end::Details-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-info text-dark fw-bold mw-lg-400px text-start" data-kt-element="message-text">Ok, Understood!</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(in)-->
												<!--begin::Message(out)-->
												<div class="d-flex justify-content-end mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-end">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Details-->
															<div class="me-3">
																<span class="text-muted fs-7 mb-1">2 Hours</span>
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary ms-1">You</a>
															</div>
															<!--end::Details-->
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-26.jpg" />
															</div>
															<!--end::Avatar-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-primary text-dark fw-bold mw-lg-400px text-end" data-kt-element="message-text">You’ll receive notifications for all issues, pull requests!</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(out)-->
												<!--begin::Message(in)-->
												<div class="d-flex justify-content-start mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-start">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-15.jpg" />
															</div>
															<!--end::Avatar-->
															<!--begin::Details-->
															<div class="ms-3">
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary me-1">Brian Cox</a>
																<span class="text-muted fs-7 mb-1">3 Hours</span>
															</div>
															<!--end::Details-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-info text-dark fw-bold mw-lg-400px text-start" data-kt-element="message-text">You can unwatch this repository immediately by clicking here:
														<a href="https://keenthemes.com">Keenthemes.com</a></div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(in)-->
												<!--begin::Message(out)-->
												<div class="d-flex justify-content-end mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-end">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Details-->
															<div class="me-3">
																<span class="text-muted fs-7 mb-1">4 Hours</span>
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary ms-1">You</a>
															</div>
															<!--end::Details-->
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-26.jpg" />
															</div>
															<!--end::Avatar-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-primary text-dark fw-bold mw-lg-400px text-end" data-kt-element="message-text">Most purchased Business courses during this sale!</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(out)-->
												<!--begin::Message(in)-->
												<div class="d-flex justify-content-start mb-10">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-start">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-15.jpg" />
															</div>
															<!--end::Avatar-->
															<!--begin::Details-->
															<div class="ms-3">
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary me-1">Brian Cox</a>
																<span class="text-muted fs-7 mb-1">5 Hours</span>
															</div>
															<!--end::Details-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-info text-dark fw-bold mw-lg-400px text-start" data-kt-element="message-text">Company BBQ to celebrate the last quater achievements and goals. Food and drinks provided</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(in)-->
												<!--begin::Message(template for out)-->
												<div class="d-flex justify-content-end mb-10 d-none" data-kt-element="template-out">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-end">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Details-->
															<div class="me-3">
																<span class="text-muted fs-7 mb-1">Just now</span>
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary ms-1">You</a>
															</div>
															<!--end::Details-->
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-26.jpg" />
															</div>
															<!--end::Avatar-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-primary text-dark fw-bold mw-lg-400px text-end" data-kt-element="message-text"></div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(template for out)-->
												<!--begin::Message(template for in)-->
												<div class="d-flex justify-content-start mb-10 d-none" data-kt-element="template-in">
													<!--begin::Wrapper-->
													<div class="d-flex flex-column align-items-start">
														<!--begin::User-->
														<div class="d-flex align-items-center mb-2">
															<!--begin::Avatar-->
															<div class="symbol symbol-35px symbol-circle">
																<img alt="Pic" src="assets/media/avatars/150-15.jpg" />
															</div>
															<!--end::Avatar-->
															<!--begin::Details-->
															<div class="ms-3">
																<a href="#" class="fs-5 fw-bolder text-gray-900 text-hover-primary me-1">Brian Cox</a>
																<span class="text-muted fs-7 mb-1">Just now</span>
															</div>
															<!--end::Details-->
														</div>
														<!--end::User-->
														<!--begin::Text-->
														<div class="p-5 rounded bg-light-info text-dark fw-bold mw-lg-400px text-start" data-kt-element="message-text">Right before vacation season we have the next Big Deal for you.</div>
														<!--end::Text-->
													</div>
													<!--end::Wrapper-->
												</div>
												<!--end::Message(template for in)-->
											</div>
											<!--end::Messages-->
										</div>
										<!--end::Card body-->
										<!--begin::Card footer-->
										<div class="card-footer pt-4" id="kt_drawer_chat_messenger_footer">
											<!--begin::Input-->
											<textarea class="form-control form-control-flush mb-3" rows="1" data-kt-element="input" placeholder="Type a message"></textarea>
											<!--end::Input-->
											<!--begin:Toolbar-->
											<div class="d-flex flex-stack">
												<!--begin::Actions-->
												<div class="d-flex align-items-center me-2">
													<button class="btn btn-sm btn-icon btn-active-light-primary me-1" type="button" data-bs-toggle="tooltip" title="Coming soon">
														<i class="bi bi-paperclip fs-3"></i>
													</button>
													<button class="btn btn-sm btn-icon btn-active-light-primary me-1" type="button" data-bs-toggle="tooltip" title="Coming soon">
														<i class="bi bi-upload fs-3"></i>
													</button>
												</div>
												<!--end::Actions-->
												<!--begin::Send-->
												<button class="btn btn-primary" type="button" data-kt-element="send">Send</button>
												<!--end::Send-->
											</div>
											<!--end::Toolbar-->
										</div>
										<!--end::Card footer-->
									</div>
									<!--end::Messenger-->
								</div>
								<!--end::Chat drawer-->
								<!--end::Drawers-->
								<!--begin::Scrolltop-->
								<div id="kt_scrolltop" class="scrolltop" data-kt-scrolltop="true">
									<!--begin::Svg Icon | path: icons/duotune/arrows/arr066.svg-->
									<span class="svg-icon">
										<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none">
											<rect opacity="0.5" x="13" y="6" width="13" height="2" rx="1" transform="rotate(90 13 6)" fill="black" />
											<path d="M12.5657 8.56569L16.75 12.75C17.1642 13.1642 17.8358 13.1642 18.25 12.75C18.6642 12.3358 18.6642 11.6642 18.25 11.25L12.7071 5.70711C12.3166 5.31658 11.6834 5.31658 11.2929 5.70711L5.75 11.25C5.33579 11.6642 5.33579 12.3358 5.75 12.75C6.16421 13.1642 6.83579 13.1642 7.25 12.75L11.4343 8.56569C11.7467 8.25327 12.2533 8.25327 12.5657 8.56569Z" fill="black" />
										</svg>
									</span>
									<!--end::Svg Icon-->
								</div>
								<!--end::Scrolltop-->
								<!--end::Main-->
							<%--	<script>var hostUrl = "assets/";</script>--%>
							
								<!--end::Page Custom Javascript-->
								<!--end::Javascript-->
								<!--end::Body-->
							</br></div>
						</div>
					</div>


						


					</form>
				</div>
			</div>
		</div>

				<script>var hostUrl = "theme/dist/assets/";</script>
								<!--begin::Javascript-->
								<!--begin::Global Javascript Bundle(used by all pages)-->
								<script src="theme/dist/assets/plugins/global/plugins.bundle.js"></script>
								<script src="theme/dist/assets/js/scripts.bundle.js"></script>
								<!--end::Global Javascript Bundle-->
								<!--begin::Page Vendors Javascript(used by this page)-->
								<script src="theme/dist/assets/plugins/custom/leaflet/leaflet.bundle.js"></script>
								<!--end::Page Vendors Javascript-->
								<!--begin::Page Custom Javascript(used by this page)-->
								<script src="theme/dist/assets/js/custom/widgets.js"></script>
								<script src="theme/dist/assets/js/custom/modals/create-app.js"></script>
								<script src="theme/dist/assets/js/custom/modals/select-location.js"></script>
								<script src="theme/dist/assets/js/custom/apps/chat/chat.js"></script>

<%--							<script type="text/javascript" language="JavaScript">

                                document.onkeydown = function (evt) {
                                    return (evt ? evt.which : event.keyCode) != 13;
                                }





                            </script>--%>

<%--				<script type="text/javascript">
                    window.onload = function () {
                        document.getElementById('<%= txtdesc_producto.ClientID %>').focus();
                    };
                </script>--%>


		<!-- JavaScript para mostrar el loader al presionar Enter -->

	</body>
</html>