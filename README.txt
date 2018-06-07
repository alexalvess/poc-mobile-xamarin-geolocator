Objetivo:
	- Desenvolver um aplicativo que busque a localização atual do usuário e exiba/liste as academias próximas a ele,
	em um raio, máximo, de 50km. E, por fim, quando selecionar uma das academias listadas, exibir a rota entre a
	localização do usuário e a localização da academia.

Aplicativo feito em Xamarin.Forms
	. Permite que eu gere assemblies nativos para Android, iOS e Windows (UWP)

Projeto criado em .Net Standard
	. Compilado e a unidade de reutilização é o assembly

Padrão de projeto MVVM
	. Estabelecer uma separação de responsabilidades e tornar o aplicativo mais fácil de dar manutenção.
	  Baseado em UI, é uma aplicação do MVP, que é uma variação do MVC.
	  (http://netcoders.com.br/introducao-ao-mvvm)

Pacotes utilizados
	- Acr.UserDialogs = Mensagens em diálogos (popups)
	- Newtonsoft.Json = Serialização de deserialização de objetos
	- Plugin.Share = Compartilhar informação em canais de comunicação
	- Xam.Plugin.Geolocator = Capturar localização atual do usuário
	- Xam.Plugins.Forms.ImageCircle = Arredondar imagens
	- Xam.Plugins.Settings = Salvar configurações em memória
	- Xamarin.FFImageLoading = Carregar imagens da nuvem de maneira mais rápida
	- Xamarin.FFImageLoading.Transformations = Estilos/efeitos em imagens
	- Xamarin.RangeSlider = Utilizar o componente slider

	Obs.: Todos os pacotes devem ser instalados em todos os projetos, para que funcione
		  perfeitamente em todas as plataformas.

==============================================================================

O que faria se tivesse mais tempo?
	. Implementação de testes automatizados e, consequentemente, utilização
	  de CI (Continuos Integration) e CD (Continuos Delivery)
		- Utilização do Visual Studio App Center para realizar tal tarefa
	. Finalizar os testes e implementações na plataforma iOS
		- Teoricamente já está tudo implementado, bastando realizar mais testes e implementar funcionalidades específicas da plataforma
	. Acrescentar um cadastro e login de usuários mais detalhado e seguro
	. Função de "Visitar Academia"
		- Envio de email para o usuário com todos os dados da academia
		- Notificação para o responsável pela academia, relatando interesse de usuários em visitá-la
	. Função de "Academias favoritas"
		- Salvando as academias preferenciais do usuário
	. Função de "Detalhar academia"
		- Exibindo mais informações sobre a academia, tais como:
			_ Valores da mensalidade
			_ Formas de pagamento
			_ Possui personal trainer?
			_ Se possiu personal trainer, qual o valor agregado?
			_ Melhor horário para o usuário realizar atividades (de acordo com um perfil)
			_ Equipamentos disponibilizados pela academia

==============================================================================

Style Guide
	. Cor primária: #22a8ff
	. Cor Secundária: #1d93e0
	. Cor de textos:
		- #000000
		- #FFFFFF
		- #22a8ff
	. Cor transparente: #dbecf7