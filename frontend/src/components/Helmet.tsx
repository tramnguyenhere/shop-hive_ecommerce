import React from "react";

const Helmet = (props: {
  title: string;
  children: React.ReactElement<any, string | React.JSXElementConstructor<any>>;
}) => {
  document.title = props.title + " - Shop Hive";
  return <div>{props.children}</div>;
};

export default Helmet;
