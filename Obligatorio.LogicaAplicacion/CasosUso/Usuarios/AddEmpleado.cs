using Obligatorio.LogicaAplicacion.Dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class AddEmpleado : ICUAddEmpleado<UsuarioDtoAlta>
    {
        private IRepositorioUsuario _repo;
        public AddEmpleado(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Execute(UsuarioDtoAlta usuarioDto)
        {
            try
            {
                bool flag = true;

                string mail = MailUtils.GetMail(usuarioDto.Nombre, usuarioDto.Apellido, false);  //genero mail simple

                while (flag)
                {
                    Usuario usr = _repo.GetByEmail(mail);
                    if (usr != null)
                    {
                        mail = MailUtils.GetMail(usuarioDto.Nombre, usuarioDto.Apellido, true); //genero mail randomico
                    }
                    else
                    {
                        flag = false;
                    }

                }

                var usuarioDtoMail = usuarioDto with { Email = mail }; //Los records son inmutables!!


                Empleado usuario = UsuarioMapper.FromDtoEmpleado(usuarioDtoMail);
                _repo.Add(usuario);
            }

            catch (NombreExcepcion ex)
            {
                throw new NombreExcepcion(ex.Message);
            }

            catch (ApellidoExcepcion ex)
            {
                throw new ApellidoExcepcion(ex.Message);
            }

            catch (ContraseniaExcepcion ex)
            {
                throw new ContraseniaExcepcion(ex.Message);
            }



            catch (UsuarioExcepcion ex)
            {
                throw new UsuarioExcepcion(ex.Message);

            }

        }
    }
}

