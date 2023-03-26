import React from "react";
import type { Meta } from '@storybook/react';

import Header from "../components/header/header.tsx";

const meta = {
  title: "Header",
  component: Header,
};

export default meta;

export const Default = () => <Header />;