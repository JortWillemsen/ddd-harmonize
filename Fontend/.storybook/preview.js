/** @type { import('@storybook/react').Preview } */

import * as jest from "jest-mock";
window.jest = jest;

const preview = {
  parameters: {
    actions: { argTypesRegex: "^on[A-Z].*" },
    controls: {
      matchers: {
        color: /(background|color)$/i,
        date: /Date$/,
      },
    },
  },
}

export default preview
