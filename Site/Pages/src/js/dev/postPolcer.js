
function politicas(id){

	var url = id;
	var img = "";
	var titulo = "";
	var info = "";
	if (url == 1) {
		img = '<img src="images/large/politicaServicio.jpg"  alt="">';
		titulo = "POLÍTICAS RELACIONADAS CON EL SERVICIO";
		info = 'Ofrecer un servicio de ingeniería en la construcción, diseño y montaje de obras eléctricas, civiles y de comunicaciones, y en el mantenimiento de redes de comunicaciones, altamente orientado a la satisfacción de las necesidades y expectativas de los clientes, las cuales son identificadas previamente mediante estudios de las necesidades de los mismos.\
Evaluar a todos los clientes atendidos para conocer sus niveles de satisfacción con el servicio y con la empresa, siendo esto la base para la definición de los objetivos de calidad y el mejoramiento continuo.\
Trabajar arduamente en el mejoramiento de la prestación del servicio al cliente, para el cumplimiento de los objetivos de calidad de la organización y lograr así el reconocimiento de la organización en el entorno.';
	}
	if(url == 2){
		img = '<img src="images/large/servicio-al-cliente.jpg" alt="">';
		titulo = "POLÍTICAS RELACIONADAS CON EL CLIENTE";
		info = "<H4>La calidad del servicio ofrecido a nuestros clientes es responsabilidad de todas las personas de la organización.</H4>";
	}
	if(url == 3){

		img = '<img src="images/large/seguridad.jpg"  alt="">';
		titulo = "SEGURIDAD INDUSTRIAL";
		info = 'A.M.V.S.A. es una empresa sólida, confiable y de gran trayectoria a nivel nacional, dedicada a la construcción, diseño y montaje de obras eléctricas, civiles y de comunicaciones y al mantenimiento de redes de comunicaciones; así como también a la ingeniería para el diseño, montaje, operación y mantenimiento de plantas para tratamiento de gas natural y sus derivados y la comercialización de hidrocarburos líquidos y gaseosos. A.M.V. S.A. garantiza a todos sus trabajadores, subcontratistas, clientes y otras partes interesadas, un ambiente de trabajo seguro, libre de enfermedades y lesiones personales, daños a la propiedad, la sociedad y al medio ambiente; a través del cumplimiento de la legislación vigente, normas, procedimientos y otros requisitos para el control de los factores de riesgo, aspectos e impactos ambientales y disminución de la contaminación derivados de la actividad desarrollada. A.M.V. S.A. se compromete a destinar los recursos económicos, humanos y materiales necesarios para el desarrollo de las estrategias de prevención, control, mitigación, disminución y eliminación los cuales se definirán con base en su escala y naturaleza, y propiciando el mejoramiento continuo del sistema de gestión en Seguridad, Salud Ocupacional y Medio Ambiente.';
	}


	$("#imagen").html(img);
	$("#titulo").html(titulo);
	$("#titulo2").html(titulo);
	$("#informacion").html(info);
	$("#titulotipo").html("POLITICAS");
			 
}

function certificaciones (id) {
	var url = id;
	var img = "";
	var titulo = "";
	var info = "";
	if (url == 4) {
		img = '<img src="images/large/ISO_9001-2008.jpg"  alt="">';
		titulo = "CERTIFICACIÓN ISO 9001:2008";
		info = "En el año 2001, la empresa logró su primera certificación en el sistema de gestión de calidad trabajando bajo los estándares requeridos por la norma ISO 9001: 1994 Posteriormente en agosto de 2003 se llevó a cabo la transición a la versión 2000 de la misma norma, logrando la certificación por 3 años. Haciendo un seguimiento permanente al cumplimiento de los requisitos de la norma en cada uno de los procesos durante estos 3 años, AMV S.A. fortaleció su sistema quedando vigente hasta septiembre de 2009.";
	}
	if(url == 5){
		img = '<img src="images/large/logo_ruc.jpg" alt="">';
		titulo = "CALIFICACION RUC";
		info = "AMV se encuentra inscrita desde el 2008 al Registro Uniforme de Evaluación del Sistema de Gestión en Seguridad, Salud Ocupacional y Ambiente – SSOA para Contratistas - RUC® en el Consejo Colombiano de Seguridad, quienes evalúan anualmente la gestión a las empresas como contratista del sector hidrocarburos, y se ha demostrado un mejoramiento continuo del mismo, cumpliendo hoy en día con 85 puntos de 100 puntos evaluables en este campo.";
	}
	if(url == 6){
		img = '<img src="images/large/certificacion_ohsas_18001.png"  alt="">';
		titulo = "CERTIFICACION OHSAS 18001:2007";
		info = "En febrero de 2.011, el Consejo Colombiano de Seguridad, otorgó el Certificado en OSHAS 18001:2007, demostrando así el mejoramiento de las condiciones de trabajo y reduciendo los daños tanto personales como materiales, y protegiendo los recursos fundamentales de la organización como son el capital humano. La certificación OHSAS 18001 permite a AMV ser más competitiva y una mejor posición en el mercado actual.";
	}


	$("#imagen").html(img);
	$("#titulo").html(titulo);
	$("#titulo2").html(titulo);
	$("#informacion").html(info);
	$("#titulotipo").html("CERTIFICACIONES");
}
