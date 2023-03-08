import { ThemeProvider } from "@emotion/react";
import { CssBaseline } from "@mui/material";
import theme from "../Assets/Theme/theme";

export const Layout = (props: any) => {
    return (
        <ThemeProvider theme={theme}>
            <CssBaseline />
            <main>{props.children}</main>
        </ThemeProvider>
    );
}