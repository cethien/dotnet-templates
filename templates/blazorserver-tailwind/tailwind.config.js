/** @type {import('tailwindcss').Config} */
module.exports = {
	content: [
		'./Pages/*.{html,js,cshtml,razor}',
		'./Shared/*.{html,js,cshtml,razor}',
		'./Components/*.{html,js,cshtml,razor}',
		'./wwwroot/*.{html,js,cshtml,razor}',
	],
	theme: {
		extend: {},
	},
	plugins: [],
	darkMode: 'class',
};
