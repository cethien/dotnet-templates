/** @type {import('tailwindcss').Config} */
module.exports = {
	content: [
		'./Pages/*.{html,js,cshtml,razor}',
		'./Shared/*.{html,js,cshtml,razor}',
		'./Components/*.{html,js,cshtml,razor}',
		'./wwwroot/*.{html,js,cshtml,razor}',
	],
	theme: {
		extend: {
			colors: {
				primary: '#0369a1',
				secondary: '#0284c7',
				hover: '#bae6fd',
				text: '#000000',

				'dark-bg-primary': '#475569',
				'dark-bg-secondary': '#1e293b',
				'dark-primary': '#38bdf8',
				'dark-secondary': '#0284c7',
				'dark-hover': '#334155',
				'dark-text': '#FFFFFF',
			},
		},
	},
	plugins: [],
	darkMode: 'class',
};
